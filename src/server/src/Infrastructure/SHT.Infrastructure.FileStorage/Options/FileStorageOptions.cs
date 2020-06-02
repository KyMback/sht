namespace SHT.Infrastructure.FileStorage.Options
{
    public class FileStorageOptions
    {
        public FileStorageType StorageType { get; set; }

        public FileSystemStorageOptions FileSystemStorageOptions { get; set; }
    }
}