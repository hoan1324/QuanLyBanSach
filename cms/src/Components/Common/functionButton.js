import { useState } from "react"
import React from "react"
import { Input, Drawer, Flex, Popconfirm,  message, Form,  Modal, Button, Empty } from "antd"
import checkDefaultFolder from "../../CommonHelper/utils/helper/defaultFolderHelper"
import services from "../../boot/services"
import { FaRegCopy } from "react-icons/fa";
import { AiOutlineFolderAdd, AiOutlineExclamationCircle } from "react-icons/ai";
import { MdDelete, MdOutlineMoveUp, MdOutlineFileDownload, MdArrowBackIosNew } from "react-icons/md";
import { LuPencilLine } from "react-icons/lu";
import TemplateExtension from "./templateExtension";
import { childrenAttachmentFolder, subsequentRankList } from "../../CommonHelper/utils/helper/recursionHelper";
import InputModal from "./inputModal";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
import CommonButton from "./commonBtn"

const actionAsync = async (service, request) => {
  try {
    console.log("Gia trị request");

    console.log(request);

    let response;
    if (request.id === undefined) {
      response = await service.create(request)
    }
    else {
      response = await service.update(request.id, request)
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
const deleteAsync = async (service, id) => {
  try {
    const response = await service.delete(id)
    if (response.status === 500) {
      return { isSuccess: false, message: response.message };
    }
    return response
  }
  catch (error) {
    console.log(error)
    console.log("lỗi vào đây");
    return {
      isSuccess: false,
      message: "Có lỗi xảy ra trong quá trình xử lý.",
    };
  }
}

const { TextArea } = Input
function FunctionButton({handleFinish, resetField, status, fetchDataFolder, fetchDataFile, dataFolder, currentFolder, currentFile }) {
  const [isOpen, setIsOpen] = useState(false)
  const [openModal, setOpenModal] = useState(false)
  const [openMenu, setOpenMenu] = useState({ open: false, action: "" })
  const [actionParent, setActionParent] = useState([null])
  const [form, formSearch] = Form.useForm()
  const [currentSelect, setCurrentSelect] = useState()
  const handleDelete = async (service, id) => {
    try {
      const response = await deleteAsync(service, id);

      if (response.isSuccess) {

        message.success(response.messsage)
        if (status === "file") {
          await fetchDataFile();
        }
        else {
          await fetchDataFolder();
          resetField()
        }
      } else {
        message.error(response.messsage)
      }
    } catch (error) {
      console.log(error);

      message.error("Co loi ")
    }
  }
  const handleRename = () => {
    if (status === "file") {
      const value = { ...currentFile, url: urlApi(currentFile.url) }
      form.setFieldsValue(value)
      setIsOpen(true)
    }
    else {
      form.setFieldsValue(currentFolder)
      setOpenModal(true)
    }
  }
  const handleClose = () => {
    if (openModal) {
      {
        form.resetFields()
        setOpenModal(false)
      }
    }
    if (isOpen) {
      setIsOpen(false)

    }
  }
  const handleSubmit = async () => {
    try {
      await form.validateFields(); // Validate tất cả các trường trước khi submit
      form.submit(); // Submit form nếu validate thành công
    } catch (error) {
      console.log('Vui lòng kiểm tra các trường hợp lỗi!');
    }
  };
  const onFinish = async (values) => {

    try {
      let service;
      if (status === "file") {
        service = services.attachment
        if (values.id !== undefined) {
          values = {
            ...currentFile,
            name: values.name.includes(`.${currentFile.extention}`) ? values.name : `${values.name}${currentFile.extention}`,
          }
        }
      }
      else {
        service = services.attachmentFolder
        if (values.id === undefined && currentFolder === undefined) {
          values.parentId = null
        }
        if (currentFolder !== undefined) {
          values.parentId = currentFolder.id
        }
        if (values.id !== undefined) {
          values = {
            ...currentFolder,
            name: values.name,
            description: values.description
          }
        }
      }
      console.log("Gía trị value");

      const response = await actionAsync(service, values);

      if (response.isSuccess) {

        message.success(response.messsage)

        if (status === "file") {
          await fetchDataFile();
        }
        else {
          await fetchDataFolder();
        }
      } else {
        message.error(response.messsage)

      }
    } catch (error) {
      console.log(error);

      message.error("Co loi ")

    } finally {
      handleClose();
    }
  }
  const handleDownLoad = async (url, name) => {
    try {
      console.log("Bắt đầu tải file...");

      const response = await fetch(url, { cache: 'no-cache' });
      if (!response.ok) throw new Error("Tải file thất bại");

      const blob = await response.blob();
      const urlDownLoad = window.URL.createObjectURL(blob);

      const downLoadFile = document.createElement('a');
      downLoadFile.href = urlDownLoad;
      downLoadFile.download = name;
      document.body.appendChild(downLoadFile);
      downLoadFile.click();
      downLoadFile.remove();

      setTimeout(() => window.URL.revokeObjectURL(urlDownLoad), 3000);

      console.log("Tải file thành công!");
    } catch (error) {
      console.error('Lỗi khi tải file:', error);
    }
  };
  const handleOk = async (service) => {
    if (currentSelect === undefined) {
      message.error("Vui lòng chọn thư mục")
      return
    }

    let value;
    if (openMenu.action === "Sao chép") {
      value = {
        ...currentFile,
        attachmentFolderId: currentSelect.id,
        id: undefined
      }
    }
    if (openMenu.action === "Di chuyển") {
      value = {
        ...currentFile,
        attachmentFolderId: currentSelect.id,
      }
    }
    try {

      const response = await actionAsync(service, value);

      if (response.isSuccess) {
        message.success(`${openMenu.action} thành công`)
        fetchDataFile();

      } else {
        message.error(`${openMenu.action} thất bại`)
      }
    } catch (error) {
      message.error("Co loi ")
    }
    finally {
      setOpenMenu(pre => ({ ...pre, open: false, action: "" }));
      setActionParent([null])
      setCurrentSelect(undefined)
    }


  }
  if (status === "file") {
    const service = services.attachment
    return (
      <div>
        <Flex justify="space-between" gap={10} wrap>
          <Flex wrap gap={10}>
            <Popconfirm
              title="Xóa tệp"
              description={
                <>
                  <p>Bạn có chắc chắn muốn xóa tệp  {currentFile?.name || ""} không?</p>
                </>
              }
              onConfirm={() => handleDelete(service, currentFile.id)}
              okText="Xác nhận"
              cancelText="Hủy"
            >
              <Button icon={<MdDelete />}>Xóa tệp</Button>
            </Popconfirm>
            <Button onClick={handleRename} icon={<LuPencilLine />}>Đổi tên tệp</Button>
            <Button onClick={() => setOpenMenu(pre => ({ ...pre, open: true, action: "Sao chép" }))} icon={<FaRegCopy />}>Sao chép tệp</Button>
            <Button onClick={() => setOpenMenu(pre => ({ ...pre, open: true, action: "Di chuyển" }))} icon={<MdOutlineMoveUp />}>Di chuyển tệp</Button>
            <Button onClick={() => handleDownLoad(currentFile.url, currentFile.name)} icon={<MdOutlineFileDownload />}>Tải xuống</Button>

          </Flex>
          <CommonButton handleFinish={handleFinish} formSearch={formSearch} handleClick={handleRename} fetchDataFile={fetchDataFile} currentFolder={currentFolder} />
        </Flex>
        <Modal title={
          <div>
            <Button disabled={actionParent.length <= 1} onClick={() => setActionParent((pre) => [...pre.slice(0, -1)])} icon={<MdArrowBackIosNew />}>Quay lại</Button>
            <span className="ms-3">Danh sách thư mục</span >
          </div>
        } open={openMenu.open} onOk={() => handleOk(service)} onCancel={() => setOpenMenu(pre => ({ ...pre, open: false, action: "" }))}>
          <div className="d-flex flex-column">
            {childrenAttachmentFolder(dataFolder, actionParent[actionParent.length - 1]).length > 0 ?
              childrenAttachmentFolder(dataFolder, actionParent[actionParent.length - 1]).map((data, index) => (
                <Button style={currentSelect?.id === data.id ? { color: "#4096FF" } : {}} className="py-3 mt-1 border-0  d-flex justify-content-start" onDoubleClick={() => setActionParent(pre => (Array.isArray(pre) ? [...pre, data.id] : [data.id]))} onClick={() => setCurrentSelect(data)} key={data.id}>
                  {data.name}
                </Button>
              ))
              : <Empty />
            }
          </div>
        </Modal>
        <InputModal title={"Tạo mới "} handleOk={handleSubmit} handleClose={handleClose} isOpen={openModal}>
          <Form onFinish={onFinish} form={form} name="attachmentFolder" layout="vertical">
            <Form.Item name="id" hidden >
              <Input disabled />
            </Form.Item>
            <Form.Item name="name" label="Tên thư mục" rules={[{ required: true, message: "Vui lòng nhập tên thư mục" }]}>
              <Input placeholder="Nhập tên thư mục" className="w-100"></Input>
            </Form.Item>
            <Form.Item name="description" label="Mô tả thư mục" >
              <TextArea placeholder="Nhập mô tả công việc"
                autoSize={{
                  minRows: 4,
                  maxRows: 6,
                }}></TextArea>
            </Form.Item>
          </Form>
        </InputModal>
        <Drawer
          footer={currentFile === undefined ? undefined :
            <div style={{ textAlign: 'right' }}>
              <Button onClick={() => setIsOpen(false)} style={{ marginRight: 8 }}>
                Thoát
              </Button>
              <Button type="primary" onClick={handleSubmit}>
                Lưu
              </Button>
            </div>
          }
          closable={false} getContainer={false} title="Chi tiết thư mục" onClose={() => setIsOpen(false)} open={isOpen}>
          {currentFile &&
            <div>
              <TemplateExtension className="my-3 d-flex justify-content-center align-items-center" style={{ height: 192 }} extension={currentFile.extention} url={urlApi(currentFile?.url)}></TemplateExtension>
              <p style={{ height: 15 }}>Kích thước : {currentFile.size} KB</p>
              <p className="mb-0">Ngày tạo : {currentFile.createdDate ? new Date(currentFile.createdDate).toLocaleDateString("vi-VN") : ""}</p>
              <Form onFinish={onFinish} form={form} initialValues={currentFile} name="attachment" layout="vertical">
                <Form.Item name="id" hidden >
                  <Input disabled />
                </Form.Item>
                <Form.Item name="name" label="Tên tệp" rules={[{ required: true, message: "Vui lòng nhập tên tệp" }]}>
                  <Input placeholder="Nhập tên tệp" className="w-100"></Input>
                </Form.Item>
                <Form.Item label="Đường dẫn" name="url" >
                  <Input className="w-100" disabled />
                </Form.Item>
              </Form>
            </div>
          }
        </Drawer>
      </div>
    )
  }
  else {
    const service = services.attachmentFolder
    return (
      <div>
        <Flex justify="space-between" gap={10} wrap>
          <Flex wrap gap={10}>
            <Button onClick={() => setOpenModal(true)} icon={<AiOutlineFolderAdd />}>Thêm thư mục</Button>
            <Popconfirm
              title="Xóa thư mục"
              description={
                <>
                  <p>Bạn có chắc chắn muốn xóa thư mục {currentFolder?.name || ""} không?</p>
                  <p><strong>Lưu ý:</strong> Tất cả các tệp và thư mục con sẽ bị xóa!</p>
                </>
              }
              onConfirm={() => handleDelete(service, currentFolder.id)}
              okText="Xác nhận"
              cancelText="Hủy"
            >
              <Button hidden={currentFolder !== undefined ? checkDefaultFolder(currentFolder.name) : true} icon={<MdDelete />}>Xóa thư mục</Button>
            </Popconfirm>
            <Button onClick={handleRename} hidden={currentFolder !== undefined ? checkDefaultFolder(currentFolder.name) : true} icon={<LuPencilLine />}>Đổi tên  thư mục</Button>
          </Flex>
          <CommonButton handleFinish={handleFinish} formSearch={formSearch} handleClick={() => setIsOpen(true)} fetchDataFile={fetchDataFile} currentFolder={currentFolder} />
        </Flex>
        <InputModal title={"Tạo mới "} handleOk={handleSubmit} handleClose={handleClose} isOpen={openModal}>
          <Form onFinish={onFinish} form={form} name="attachmentFolder" layout="vertical">
            <Form.Item name="id" hidden >
              <Input disabled />
            </Form.Item>
            <Form.Item name="name" label="Tên thư mục" rules={[{ required: true, message: "Vui lòng nhập tên thư mục" }]}>
              <Input placeholder="Nhập tên thư mục" className="w-100"></Input>
            </Form.Item>
            <Form.Item name="description" label="Mô tả thư mục" >
              <TextArea placeholder="Nhập mô tả công việc"
                autoSize={{
                  minRows: 4,
                  maxRows: 6,
                }}></TextArea>
            </Form.Item>
          </Form>
        </InputModal>
        <Drawer closable={false} getContainer={false} title="Chi tiết" onClose={() => setIsOpen(false)} open={isOpen}>
          {currentFolder &&
            <div>
              <div>Tên thư mục : {currentFolder.name}</div>
              <div>Mô tả : {currentFolder.description}</div>
              <div>Ngày tạo : {currentFolder.createdDate ? new Date(currentFolder.createdDate).toLocaleDateString("vi-VN") : ""}</div>
              <div>Ngày sửa : {currentFolder.modifiedDate ? new Date(currentFolder.modifiedDate).toLocaleDateString("vi-VN") : ""}</div>

            </div>
          }
        </Drawer>
      </div>
    )
  }
}

export default FunctionButton