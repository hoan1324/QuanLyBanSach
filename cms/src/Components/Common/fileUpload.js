import { Button, Upload,message } from "antd"
import { UploadOutlined } from '@ant-design/icons'
import services from "../../boot/services"
const UploadFile = async (lengthFile, service, folderId, formData) => {
    try {
        let response;
        if (lengthFile > 1) {
            response = service.uploadFiles(folderId, formData)
        }
        else {
            response = service.uploadFile(folderId, formData)
        }
        if (response.status === 500) {
            return { isSuccess: false, message: response.message };
        }
        return response
    }
    catch (error) {
        console.log("lỗi vào đây");
        return {
            isSuccess: false,
            message: "Có lỗi xảy ra trong quá trình xử lý.",
        };
    }

}
function FileUpload({ folderId }) {
    const service = services.attachmentFolder
    const customRequest = async (options) => {
        if (folderId === undefined) {
            console.log("lỗi undifines");
            
            return
        }
        try {
            const { file } = options;
            const files = Array.isArray(file) ? file : [file];  // Nếu là mảng thì giữ nguyên, nếu không thì chuyển thành mảng
            const formData = new FormData();
            files.forEach((fileItem, index) => {
                formData.append(`file-${index}`, fileItem);
            })
            const response=await UploadFile(files.length,service,folderId,formData)
            console.log(response);
             
        }
        catch (error) {
            console.log(error);
            console.log("Lỗi");


        }
    }
    const beforeUpload = (file, fileList) => {
        const imageTypes = ['.jpeg','.jpg','.png','.gif','.bmp','.webp','.tiff'];
        const documentTypes = ['.doc','.docx','.ppt','.pptx','.xls','.xlsx','.odt','.pdf','.txt'];
        const videoTypes = ['.avi','.mov','.webm','.mp4'];
        const audioTypes=['.mp3','.flac','.aac','.ogg']
        const compressedTypes=['.7z','.rar','.zip','.gz']
        
        const fileExtension = file.name.toLowerCase().split('.').pop(); // Lấy phần mở rộng của file
        const fileSizeMB = file.size / 1024 / 1024; // Kích thước file tính theo MB
      
        // Kiểm tra kích thước file
        if (imageTypes.includes(`.${fileExtension}`)) {
          if (fileSizeMB > 5) {
            //message.error(`${file.name} (Hình ảnh) phải có kích thước nhỏ hơn 5MB!`);
            return false;
          }
        } else if (documentTypes.includes(`.${fileExtension}`)) {
          if (fileSizeMB > 10) {
            //message.error(`${file.name} (Tài liệu) phải có kích thước nhỏ hơn 10MB!`);
            return false;
          }
        } else if (audioTypes.includes(`.${fileExtension}`) && videoTypes.includes(`.${fileExtension}`)) {
          if ( fileSizeMB > 100) {
            //message.error(`${file.name} (Media) phải có kích thước từ 50MB đến 100MB!`);
            return false;
          }
        }
        else if (compressedTypes.includes(`.${fileExtension}`)) {
          if ( fileSizeMB > 200) {
            return false;
          }
        } else {
          //message.error(`${file.name} không phải là loại file hợp lệ!`);
          return false;
        }
      
        return true; // File hợp lệ
      };
    return (

        <Upload customRequest={customRequest} beforeUpload={beforeUpload} multiple >
            <Button icon={<UploadOutlined />}>Tải tệp lên</Button>
        </Upload>
    )
}
export default FileUpload