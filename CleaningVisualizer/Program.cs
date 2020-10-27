using Cleaning.Controllers;
using Cleaning.Models.PostModels;
using Cleaning.Models.ViewModels;
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

                Date = new DateTime(2021, 01, 08, 13, 00, 00),
                FullName = "Daria Cagle",
                Phone = "+380955866452",
                CleaningType = "Extra Cleaning"
            };

            controller.CreateCleaningRequest(model);

            CleaningViewModel viewModel = controller.GetById(1);
            Console.WriteLine(viewModel.FullName);

            Console.WriteLine();

            var allModels = controller.GetAll();
            foreach(var mod in allModels)
            {
                Console.WriteLine(mod.FullName);
            }
            
        }
    }
}
