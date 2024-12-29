using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOCL_MARINE_NEW.AppCode
{
    public class Average_Discharge_Time
    {
        public int DischargeId { get; set; }
        public int Id { get; set; }
        public string TankerNumber { get; set; }
        public string TurnArroundTime { get; set; }
        public string Year1 { get; set; }
    }

    public class Crude_Unloaded_Monthly
    {
        public int CrudMonthlyId { get; set; }
        public int Mon_Id { get; set; }
        public string MmtMonthly { get; set; }
        public string Month1 { get; set; }
    }

    public class Crude_Unloaded_Yearly
    {
        public int CrudeYearId { get; set; }
        public int Id { get; set; }
        public string MmtYear { get; set; }
        public string Year1 { get; set; }
    }

    public class Month
    {
        public int Mon_Id { get; set; }
        public string Month1 { get; set; }
    }

    public class Ocean_Loss_Monthly
    {
        public int OceanLossId { get; set; }
        public int Mon_Id { get; set; }
        public string KlPercentage { get; set; }
        public string Month1 { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string Description { get; set; }
    }

    public class Tanker_Milestone
    {
        public int MilestoneId { get; set; }
        public DateTime Date1 { get; set; }
        public string TankerNumber { get; set; }
    }

    public class Total_Tanker_Vlcc
    {
        public int VLCCId { get; set; }
        public int Id { get; set; }
        public string Total_Tanker { get; set; }
        public string VLCC { get; set; }
        public string Year1 { get; set; }
    }

    public class Turn_Arround_Time
    {
        public int TurnArroundId { get; set; }
        public int Id { get; set; }
        public string TankerNumber { get; set; }
        public string TurnArroundTime { get; set; }
        public string Year1 { get; set; }
    }

    public class User_
    {
        public int UID { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public int RoleId { get; set; }
    }

    public class Year_
    {
        public int Id { get; set; }
        public string Year1 { get; set; }
        public string Status { get; set; }
    }
}