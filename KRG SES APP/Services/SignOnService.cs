using KRG_SES_APP.Models.SignInSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KRG_SES_APP.Services
{
    public class SignOnService
    {
        public event Action<CurrentAttendance> OnCurrentAttendanceChange;

        private readonly string HistoricalCollection = "historicalsignon";
        private readonly string CurrentCollection = "currentlysignedon";

        AuthenticationService authenticationService;
        CurrentAttendance _currentAttendance;
        CurrentAttendance currentAttendance
        {
            get => _currentAttendance;
            set
            {
                OnCurrentAttendanceChange?.Invoke(value);
                _currentAttendance = value;
            }
        }

        public SignOnService(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        //Calls
        //1x Read
        public async Task Initilize()
        {
            var memberID = await GetMemberID();
            var memberIDString = memberID.ToString();

            await UpdateCurrentAttendance(memberIDString);
        }

        //Calls
        //1x Read
        //1x Write
        public async Task SignIn(string catagory)
        {
            var memberID = await GetMemberID();
            var memberIDString = memberID.ToString();

            await UpdateCurrentAttendance(memberIDString);

            if (currentAttendance == null)
            {
                var newAttendance = new CurrentAttendance()
                {
                    Catagory = catagory,
                    MemberID = memberID,
                };

                await FirestoreTools.SetDocument(
                    CurrentCollection,
                    memberIDString,
                    newAttendance);

                currentAttendance = newAttendance;
            }
        }

        //Calls
        //1x Read
        //1x Write
        //1x Remove
        public async Task SignOut()
        {
            var memberID = await GetMemberID();
            var memberIDString = memberID.ToString();

            await UpdateCurrentAttendance(memberIDString);

            if (currentAttendance != null)
            {
                await FirestoreTools.RemoveDocument(CurrentCollection, memberIDString);
                await FirestoreTools.AddDocument(HistoricalCollection, new HistoricAttendance(currentAttendance));
                currentAttendance = null;
            }
        }

        private async Task UpdateCurrentAttendance(string memberID)
        {
            currentAttendance = await FirestoreTools.GetDocument<CurrentAttendance>(CurrentCollection, memberID);
        }

        private async Task<int> GetMemberID()
        {
            return (await authenticationService.GetLogInInfo()).MemberNumber;
        }
    }
}
