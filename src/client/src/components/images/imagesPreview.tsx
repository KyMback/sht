import { FileInfo } from "../controls/files/simpleFilesUpload";
import { FilesApi } from "../../core/api/http/filesApi";
import React from "react";

export const ImagesPreview = ({ images }: { images: Array<FileInfo> }) => {
    return (
        <div className="images-preview-container">
            {images.map((image, index) => (
                <div
                    className="image-container clickable"
                    key={index}
                    onClick={_ => window.open(FilesApi.getLinkToDownload(image.id))}
                >
                    <img src={FilesApi.getLinkToDownload(image.id)} alt={image.name} />
                </div>
            ))}
        </div>
    );
};
