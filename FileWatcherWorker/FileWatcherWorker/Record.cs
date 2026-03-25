namespace FileWatcherWorker
{
    public class Record
    {
        public string SeqNo { get; set; }
        public string CustomerName { get; set; }
        public string CardNo { get; set; }
        public string ExpiryDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string GetRecordString()
        {
            return $"#SEQNO#{SeqNo}" +
                   $"#CUSTNAME#{CustomerName}" +
                   $"#CARDNO#{CardNo}" +
                   $"#EXPDATE#{ExpiryDate}" +
                   $"#ADDRESS1#{Address1}" +
                   $"#ADDRESS2#{Address2}" +
                   $"#ENDRC#";
        }
    }
}