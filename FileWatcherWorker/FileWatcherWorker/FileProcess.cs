using System.Text;

namespace FileWatcherWorker
{
    public class FileProcess
    {
        private List<Record> recordList;
        public string FilePath { get; set; }

        public FileProcess(string unprocessedFilePath)
        {
            FilePath = unprocessedFilePath;
            recordList = new List<Record>();
        }

        public void Start(string outputFolder)
        {
            recordList = ParseData2RecordList(FilePath);

            string outputFileName = Path.GetFileNameWithoutExtension(FilePath) + "_processed.txt";
            string outputFilePath = Path.Combine(outputFolder, outputFileName);

            GenerateOutputFile(outputFilePath, recordList);

            File.Delete(FilePath);
        }
        private List<Record> ParseData2RecordList(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var records = new List<Record>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('*', StringSplitOptions.RemoveEmptyEntries);

                // Expected structure:
                // [1, seqNo, 2, name, 3, card, 4, expiry, 5, addr1, 6, addr2, END]

                if (parts.Length < 12)
                    continue; // skip bad records

                var record = new Record
                {
                    SeqNo = parts[1],
                    CustomerName = parts[3],
                    CardNo = parts[5],
                    ExpiryDate = parts[7],
                    Address1 = parts[9],
                    Address2 = parts[11]
                };

                records.Add(record);
            }

            return records;
        }

        private void GenerateOutputFile(string outputFilePath, List<Record> recordList)
        {
            var sb = new StringBuilder();

            foreach (var record in recordList)
            {
                sb.AppendLine(record.GetRecordString());
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}