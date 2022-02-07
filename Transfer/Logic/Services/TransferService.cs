using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Logic.Services
{
    public class TransferService : ITransferService
    {
        private readonly ILogger<TransferService> _logger;

        public TransferService(ILogger<TransferService> logger)
        {
            _logger = logger;
        }

        public int[] Initialize(int arrayLength)
        {
            Random random = new();
            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
                array[i] = random.Next();

            return array;
        }

        public int[] Transfer(int[] generatedNumbers)
        {
            if (generatedNumbers == null)
                return new int[1];

            List<int> transferedNumbwers = new List<int>();
            ConcurrentQueue<int> concurrentQueue = new();

            var task1 = Task.Factory.StartNew(() =>
            {
                    for (int i = 0; i < generatedNumbers.Count(); i++)
                    {
                        concurrentQueue.Enqueue(generatedNumbers[i]);
                        _logger.LogInformation($"Items {generatedNumbers[i]} added to queue.");
                    }
            });

            task1.Wait();
            var task2 = new Task(() =>
            {
                int result;

                    while (concurrentQueue.TryDequeue(out result))
                    {
                        transferedNumbwers.Add(result);
                        _logger.LogInformation($"Items {result} removed from queue.");
                    }
                Thread.Sleep(600);
            });

            if (task1.IsCompleted)
            {
                task2.Start();
                task2.Wait();
            }
            return transferedNumbwers.ToArray();
        }
    }
}
