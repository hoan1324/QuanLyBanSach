import { Button, Upload, message } from "antd"
import { UploadOutlined } from '@ant-design/icons'
import services from "../../boot/services"
import { useState } from "react";
import { imageTypes, documentTypes, videoTypes, audioTypes, compressedTypes } from "../../CommonHelper/Constant/extensionFiles";
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

function FileUpload({ folderId,fetchDataFile }) {
  const service = services.attachmentFolder
  const [showUpload, setShowUpload] = useState(false)
   

  const customRequest = async (options) => {
    const { file, onProgress, onSuccess, onError } = options;
    
    if (folderId === undefined) {
      setShowUpload(false)
      message.error("Vui lòng chọn thư mục chứa")
      return
    }

    // Tăng tiến độ từ 0% đến 70% (mô phỏng quá trình tải lên)

    try {

      setShowUpload(true)
     

      const files = Array.isArray(file) ? file : [file];  // Nếu là mảng thì giữ nguyên, nếu không thì chuyển thành mảng
      const formData = new FormData();
      files.forEach((fileItem, index) => {
        formData.append(`file-${index}`, fileItem);
      })

      
      const response = await UploadFile(files.length, service, folderId, formData)
      if (response.isSuccess) {
        message.success(response.messsage)
        onSuccess(response, file);
        await fetchDataFile()
      }
      else {
        message.error(response.messsage)
        onError(response, file);
       
      }
    }
    catch (error) {
      console.log(error);
      onSuccess("Lỗi", file)
      message.error("Có lỗi xảy ra trong hệ thống")
      
    }
    finally{
      setTimeout(()=>setShowUpload(false),3000)
    }
  


  }
  const beforeUpload = (file, fileList) => {

    const fileExtension = file.name.toLowerCase().split('.').pop(); // Lấy phần mở rộng của file
    const fileSizeMB = file.size / 1024 / 1024; // Kích thước file tính theo MB

    // Kiểm tra kích thước file
    if (imageTypes.includes(`.${fileExtension}`)) {
      if (fileSizeMB > 5) {
        message.error(`${file.name} (Hình ảnh) phải có kích thước nhỏ hơn 5MB!`);
        return false;
      }
    } else if (documentTypes.includes(`.${fileExtension}`)) {
      if (fileSizeMB > 10) {
        message.error(`${file.name} (Tài liệu) phải có kích thước nhỏ hơn 10MB!`);
        return false;
      }
    } else if (audioTypes.includes(`.${fileExtension}`) || videoTypes.includes(`.${fileExtension}`)) {
      if (fileSizeMB > 100) {
        message.error(`${file.name} (Media) phải có kích thước từ 50MB đến 100MB!`);
        return false;
      }
    }
    else if (compressedTypes.includes(`.${fileExtension}`)) {
      if (fileSizeMB > 200) {
        message.error(`${file.name} (nen) phải có kích thước từ 50MB đến 100MB!`);
        return false;
      }
    } else {
      //message.error(`${file.name} không phải là loại file hợp lệ!`);
      return false;
    }

    return true; // File hợp lệ
  };

  return (

    <Upload showUploadList={showUpload} customRequest={customRequest} beforeUpload={beforeUpload} multiple >
      <Button icon={<UploadOutlined />}>Tải tệp lên</Button>
    </Upload>
  )
}
export default FileUpload