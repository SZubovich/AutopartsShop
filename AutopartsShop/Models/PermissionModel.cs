namespace AutopartsShop.Models
{
    public class PermissionModel
    {
        public bool Admin { get; set; }

        public bool ContentManager { get; set; }

        public bool Courier { get; set; }

        public bool Seller { get; set; }

        public static string GetRoleName(PermissionModel model)
        {
            return model.Admin ? "ADMIN" :
                   model.ContentManager ? "CONTENT" :
                   model.Seller ? "SELLER" :
                   model.Courier ? "COURIER" :
                   string.Empty;
        }
    }
}
