namespace Ticketing.Domain.Model.Groups
{
    public enum TicketingPermission
    {
        RegisterTicket=100,
        DeleteTicket=101,
        ViewTicket=102,
        OpenTicket = 103,
        CloseTicket=104,

        WriteTicketComment = 201,
        DeleteTicketComment=202,
        ViewTicketComment = 201,

        CreateUser = 300,
        DeleteUser = 301,
        ViewUser = 302,
        UpdateUser = 303,

        CreateDepartment = 400,
        DeleteDepartment = 401,
        ViewDepartment = 402,
        UpdateDepartment = 403,

        //IgnorePermission=500,

        ViewCartable=600,
        ReferralTicketCartable = 601,

        ViewDepartmentBy=700,
        ViewAllDepartmkent = 701

    }
}
