using Cleaning.Controllers;
using Cleaning.Models.PostModels;
using System;

namespace CleaningVisualizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new CleaningController();
            var model = new CreateCleaningPostModel
            {
                Date = DateTime.UtcNow,
                FullName = "Daria Cagle",
                Phone = "+380955866452",
                CleaningType = "Extra Cleaning"

            };
        }
    }
}
