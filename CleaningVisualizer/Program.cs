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

                Date = new DateTime(2021, 01, 09, 07, 00, 00),
                FullName = "John Smith",
                Phone = "+380955555555",
                CleaningType = "Super Cleaning"
            };

            var cleaningViewModel = controller.CreateCleaningRequest(model);

            Console.WriteLine(cleaningViewModel.Id);

            CleaningViewModel viewModel = controller.GetById(1);
            Console.WriteLine(viewModel.FullName);

            Console.WriteLine();

            var allModels = controller.GetAll();
            foreach (var mod in allModels)
            {
                Console.WriteLine(mod.FullName);
            }

        }
    }
}
