using System.Collections.Generic;

namespace DLL.DTO
{
    public class CarBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public List<CarModel> CarModels { get; set; }
    }
}
