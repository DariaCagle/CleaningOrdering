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

                Date = new DateTime(2020, 01, 08, 10, 00, 00),
                FullName = "Daria Cagle",
                Phone = "+380955866452",
                CleaningType = "Extra Cleaning"
            };

            controller.CreateCleaningRequest(model);

            CleaningViewModel viewModel = controller.GetById(0);
            Console.WriteLine(viewModel.FullName);
        }
    }
}
