using Assignment.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Assignment.Tests.Loaders
{
    // Ovi testovi proveravaju logiku LoadersViewModel-a.
    //
    // Ocekivano na LoadersViewModel:
    //   - lista thread-ova (npr. IList<ThreadWorker> Threads) — uvek tacno 3
    //   - double TotalProgress — prosek Progress-a SAMO aktivnih (ne-cancelovanih) thread-ova;
    //                            vraca 0 ako su svi thread-ovi cancelovani

    [TestClass]
    public class LoadersViewModelTests
    {
        [TestMethod]
        public void Threads_OnInitialization_ContainsExactlyThree()
        {
            // Arrange
            // Kreiraj LoadersViewModel
            var vm = new LoadersViewModel();

            // Assert
            // Ocekujemo tacno 3 thread-a
            Assert.AreEqual(3, vm.ThreadProgressList.Count);
        }

        [TestMethod]
        public void TotalProgress_WhenOneThreadCancelled_ExcludesCancelledThread()
        {
            // Arrange
            // Kreiraj LoadersViewModel i postavi poznate vrednosti Elapsed-a na sva 3 thread-a
            // tako da im je Progress redom 40%, 60%, 80%
            var vm = new LoadersViewModel();

            vm.ThreadProgressList[0].Thread.ExecutionTime = 50;
            vm.ThreadProgressList[1].Thread.ExecutionTime = 30;
            vm.ThreadProgressList[2].Thread.ExecutionTime = 10;

            vm.ThreadProgressList[0].Thread.Elapsed = 20;
            vm.ThreadProgressList[1].Thread.Elapsed = 18;
            vm.ThreadProgressList[2].Thread.Elapsed = 8;

            // Canceluj prvi thread
            vm.ThreadProgressList[0].Cancel(null);
            vm.CalculateTotalProgress();

            // Act
            double result = vm.TotalProgress.TotalProgress;

            // Assert
            // TotalProgress treba biti prosek preostala dva aktivna thread-a: (60 + 80) / 2 = 70
            Assert.AreEqual(70.0, result);
        }

        [TestMethod]
        public void TotalProgress_WhenAllThreadsCancelled_ReturnsZero()
        {
            // Arrange
            // Kreiraj LoadersViewModel i canceluj sva 3 thread-a
            var vm = new LoadersViewModel();
            vm.ThreadProgressList[0].Cancel(null);
            vm.ThreadProgressList[1].Cancel(null);
            vm.ThreadProgressList[2].Cancel(null);

            vm.CalculateTotalProgress();

            // Act
            double result = vm.TotalProgress.TotalProgress;

            // Assert
            Assert.AreEqual(0.0, result);
        }
    }
}
