namespace SHT.Infrastructure.FileStorage.StorageStrategies
{
    public class FileReference
    {
        public FileReference(FileStorageType storageType, string reference)
        {
            StorageType = storageType;
            Reference = reference;
        }

        public FileStorageType StorageType { get; set; }

        public string Reference { get; set; }
    }
}