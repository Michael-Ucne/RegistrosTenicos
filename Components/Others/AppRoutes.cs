namespace RegistrosTenicos.Components.Others
{
    public class AppRoutes
    {
        // Routers de Tecnicos
        public static string TIndex => "/Tecnico";
        public static string TCreate => "/Tecnico/Create";
        public static string TEdit => "/Tecnico/Edit";
        public static string TDelete => "/Tecnico/Delete";

        // Routers de Clientes
        public static string CIndex => "/Cliente";
        public static string CCreate => "/Cliente/Create";
        public static string CEdit => "/Cliente/Edit";
        public static string CDelete => "/Cliente/Delete";

        // Routers de Tickets
        public static string TIIndex => "/Ticket";
        public static string TICreate => "/Ticket/Create";
        public static string TIEdit => "/Ticket/Edit";
        public static string TIDelete => "/Ticket/Delete";

    }
}
