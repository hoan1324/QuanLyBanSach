import { Radio,Card,Popconfirm, message, Form, Input, Button, Modal, Layout, Menu, Flex, Space, Tooltip, Drawer } from "antd";
import { useState, useEffect } from "react";
import { AiOutlineFolderAdd, AiOutlineExclamationCircle } from "react-icons/ai";
import { MdDelete } from "react-icons/md";
import { CiSearch } from "react-icons/ci";
import { LuPencilLine } from "react-icons/lu";
import { attachmentFolderRecursion } from "../../CommonHelper/utils/helper/recursionHelper";
import InputModal from "./inputModal";
import checkDefaultFolder from "../../CommonHelper/utils/helper/defaultFolderHelper";
import services from "../../boot/services";
import FileUpload from "./fileUpload";
import { useForm } from "antd/es/form/Form";
const { Header, Footer, Sider, Content } = Layout;
const { TextArea } = Input;

const fetchAttachmentFolderData = async (attachmentFolder) => {
  try {
    const attachmentFolderResponse = await attachmentFolder.getListDropdown()

    if (attachmentFolderResponse.isSuccess) {

      return attachmentFolderResponse.data;
    }

    return [];
  } catch (error) {
    console.error("Lỗi trong fetchAttachmentFoldersData:", error);
    return [];
  }
};
const actionAttachmentFolderData = async (attachmentFolderService, attachmentFolderData) => {
  try {
    let response;
    if (attachmentFolderData.id === undefined) {
      response = await attachmentFolderService.create(attachmentFolderData)
    }
    else {
      response = await attachmentFolderService.update(attachmentFolderData.id, attachmentFolderData)
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
const deleteAttachmentFolderData = async (attachmentFolderService, id) => {
  try {
    const response = await attachmentFolderService.delete(id)
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

function FileManager() {
  const service = services.attachmentFolder;
  const [open, setOpen] = useState(false)
  const [collapsed, setCollapsed] = useState(false);
  const [isOpen, setIsOpen] = useState(false)
  const [data, setData] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [currentSelect, setCurrentSelect] = useState()
  const [title, setTitle] = useState();
  const [form] = useForm();
  const [openModal, setOpenModal] = useState()

  const fetchData = async () => {
    const attachmentFolder = await fetchAttachmentFolderData(service);

    setData(attachmentFolder);
  }
  const showDrawer = () => {
    setIsOpen(true);
  };
  const onClose = () => {
    setIsOpen(false);
  };
  const handleSubmit = async () => {
    try {
      await form.validateFields(); // Validate tất cả các trường trước khi submit
      form.submit(); // Submit form nếu validate thành công
    } catch (error) {
      console.log('Vui lòng kiểm tra các trường hợp lỗi!');
    }
  };
  const handleClose = () => {
    if (openModal) {
      {
        form.resetFields()
        setOpenModal(false)

      }
    }
  }

  const handleSelect = (info, openKeys) => {



    if (!collapsed && info === undefined && openKeys.length === 0) {

      setCurrentSelect(undefined)

    }
    if (info !== undefined) {
      const dataSelect = data.find(item => item.id === info)
      setCurrentSelect(dataSelect)
    }


  }
  const handleDelete = async () => {
    try {
      const response = await deleteAttachmentFolderData(service, currentSelect.id);

      if (response.isSuccess) {

        message.success(response.messsage)
        fetchData(); // Làm mới dữ liệu
      } else {
        message.error(response.messsage)
      }
    } catch (error) {
      message.error("Co loi ")
    }
  }
  const onFinish = async (values) => {

    try {

      if (values.id === undefined && currentSelect === undefined) {
        values.parentId = null
      }
      if (currentSelect !== undefined) {
        values.parentId = currentSelect.id
      }
      if (values.id !== undefined) {
        values = {
          ...currentSelect,
          name: values.name,
          description: values.description
        }
      }

      const response = await actionAttachmentFolderData(service, values);

      if (response.isSuccess) {
        console.log(response);
        
        message.success(response.messsage)

        fetchData(); // Làm mới dữ liệu
      } else {
        message.error(response.messsage)

      }
    } catch (error) {
      message.error("Co loi ")

    } finally {
      handleClose();
    }
  }
  const handleRename = () => {

    form.setFieldsValue(currentSelect)
    setOpenModal(true)
  }
  useEffect(() => {
    fetchData();


  }, []); // Chạy lại khi filter thay đổi
  return (
    <div>
      <Button onClick={() => setOpen(true)}> Mở</Button>
      <Modal className="position-relative overflow-hidden" title={"Quản lý file"} centered width={1100} onCancel={() => setOpen(false)} open={open} okText={"Chọn"}>
        <Layout className="bg-white rounded" style={{ minHeight: '800px' }}>
          <Sider className="bg-white" trigger={null} collapsible collapsed={collapsed} onMouseOut={() => setCollapsed(true)} onMouseOver={() => setCollapsed(false)} onCollapse={(value) => setCollapsed(value)} width="25%" >
            <Menu
              onSelect={(info) => handleSelect(info.key, [])}
              theme="light"
              mode="inline"
              selectedKeys={currentSelect?.id}
              onOpenChange={(openKeys) => handleSelect(openKeys[openKeys.length - 1], openKeys)}
              items={
                attachmentFolderRecursion(data, null)
              }
            />
          </Sider>
          <Layout>
            <Header className="bg-white px-2" >
              <Flex justify="space-between" wrap>
                <Space size={"middle"}>
                  <Button onClick={() => setOpenModal(true)} icon={<AiOutlineFolderAdd />}>Thêm thư mục</Button>
                  <Popconfirm
                    title="Xóa thư mục"
                    description="Bạn có chắc muốn xóa thư mục này không,nếu bạn xóa thì các thư mục và tệp thuộc thư mục này cũng sẽ bị xóa? "
                    onConfirm={handleDelete}
                    okText="Xác nhận"
                    cancelText="Hủy"
                  >
                    <Button hidden={currentSelect !== undefined ? checkDefaultFolder(currentSelect.name) : true} icon={<MdDelete />}>Xóa thư mục</Button>
                  </Popconfirm>
                  <Button onClick={handleRename} hidden={currentSelect !== undefined ? checkDefaultFolder(currentSelect.name) : true} icon={<LuPencilLine />}>Đổi tên  thư mục</Button>
                </Space>
                <Space size={"middle"}>
                  <Tooltip className="position-relative" title={"Chi tiết"}>
                    <Button onClick={showDrawer} icon={<AiOutlineExclamationCircle />}></Button>
                  </Tooltip>
                  <Tooltip title={"Tìm kiếm tên thư mục hoặc tệp"}>
                    <Button icon={<CiSearch />}></Button>
                  </Tooltip>
                  <FileUpload folderId={currentSelect===undefined?undefined:currentSelect.id} />
                </Space>
              </Flex>
            </Header>
            <Content>
              
            </Content>

          </Layout>
        </Layout>
        <InputModal title={title} handleOk={handleSubmit} handleClose={handleClose} isOpen={openModal}>
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
        <Drawer closable={false} getContainer={false} title="Chi tiết" onClose={onClose} open={isOpen}>
          <p>hehe</p>
        </Drawer>
      </Modal>
    </div>
  )
}
export default FileManager