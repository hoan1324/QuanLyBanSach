import { Button, Upload, message } from "antd"
import { UploadOutlined } from '@ant-design/icons'
import { useState, useMemo } from "react";

import services from "../../boot/services"
import { actionDiffirent } from "../../CommonHelper/utils/helper/communicateApi";
import constantType from "../../CommonHelper/Constant/constantType";

function FileUpload({ folderId, fetchDataFile }) {
  const service = services.attachmentFolder
  const [showUpload, setShowUpload] = useState(false)
  const { imageTypes, documentTypes, videoTypes, audioTypes, compressedTypes } = constantType.extension

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
      const methodName = files.length > 1 ? "uploadFiles" : "uploadFile";

      let progress = 0;
      const fakeProgress = setInterval(() => {
        progress += 10;
        onProgress({ percent: progress });
        if (progress >= 70) clearInterval(fakeProgress);
      }, 500);

      const response = await actionDiffirent(service, methodName, [folderId, formData])

      clearInterval(fakeProgress);
      onProgress({ percent: 100 });


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
      onError("Lỗi", file)
      message.error("Có lỗi xảy ra trong hệ thống")

    }
    finally {
      setTimeout(() => setShowUpload(false), 3000)
    }



  }
  const fileSizeLimits = useMemo(() => ({
    image: 5,
    document: 10,
    media: 100,
    compressed: 200
  }), []);

  // Xác định loại file
  const getFileType = (extension) => {
    if (imageTypes.includes(`.${extension}`)) return "image";
    if (documentTypes.includes(`.${extension}`)) return "document";
    if (audioTypes.includes(`.${extension}`) || videoTypes.includes(`.${extension}`)) return "media";
    if (compressedTypes.includes(`.${extension}`)) return "compressed";
    return null;
  };

  const beforeUpload = (file) => {
    const fileExtension = file.name.split('.').pop().toLowerCase();
    const fileSizeMB = file.size / 1024 / 1024;
    const fileType = getFileType(fileExtension);

    if (!fileType) {
      message.error(`${file.name} không đúng định dạng`)
      return false
    };

    if (fileSizeMB > fileSizeLimits[fileType]) {
      message.error(`${file.name} vượt quá giới hạn ${fileSizeLimits[fileType]}MB!`);
      return false;
    }

    return true;
  };

  return (

    <Upload showUploadList={showUpload} customRequest={customRequest} beforeUpload={beforeUpload} multiple >
      <Button icon={<UploadOutlined />}>Tải tệp lên</Button>
    </Upload>
  )
}
export default FileUpload