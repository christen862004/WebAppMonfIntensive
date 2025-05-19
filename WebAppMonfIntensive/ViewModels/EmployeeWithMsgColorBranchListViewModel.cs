namespace WebAppMonfIntensive.ViewModels
{
    public class EmployeeWithMsgColorBranchListViewModel
    {
        //Property foreach inf you ant to send it to View
        //Send only model property that view needd + hide real name
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        
        //Extar info
        public int Temp { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }

        //Marge with another model
        public List<string> Branches { get; set; }
    }
}
