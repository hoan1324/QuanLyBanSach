import { Button, Modal, Layout, Menu, Flex, Space, Tooltip, Drawer } from "antd";
import { useState, useEffect } from "react";
import { AiOutlineFolderAdd, AiOutlineExclamationCircle } from "react-icons/ai";
import { MdDelete } from "react-icons/md";
import { CiSearch } from "react-icons/ci";
import { LuPencilLine } from "react-icons/lu";
import { attachmentFolderRecursion } from "../../CommonHelper/utils/helper/recursionHelper";

import checkDefaultFolder from "../../CommonHelper/utils/helper/defaultFolderHelper";
import services from "../../boot/services";
import FileUpload from "./fileUpload";
const { Header, Footer, Sider, Content } = Layout;
const fetchAttachmentFolderData = async (attachmentFolder) => {
    try {
        const attachmentFolderResponse = await attachmentFolder.getListDropdown()

        if (attachmentFolderResponse.isSuccess) {
            
            return attachmentFolderResponse.data;
        }

        return [];
    } catch (error) {
        console.error("Lỗi trong fetchJobsData:", error);
        return [];
    }
};
function FileManager() {
    const service = services.attachmentFolder; 
    const [open, setOpen] = useState(false)
    const [collapsed, setCollapsed] = useState(false);
    const [isOpen, setIsOpen] = useState(false)
    const [data, setData] = useState([]); // Khởi tạo state để lưu dữ liệu
    const [currentSelect,setCurrentSelect]=useState({})

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
    const handleSelect=(info)=>{
        console.log(info.key);
        
    const dataSelect=data.find(item=>item.id===info.key)
    if(dataSelect!=null){
        setCurrentSelect(dataSelect)
    }
        
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
                        onSelect={handleSelect}
                            theme="light"
                            mode="inline"
                            items={
                                attachmentFolderRecursion(data, null)
                            }
                        />
                    </Sider>
                    <Layout>
                        <Header className="bg-white px-2" >
                            <Flex justify="space-between" wrap>
                                <Space size={"middle"}>
                                    <Button icon={<AiOutlineFolderAdd />}>Thêm thư mục</Button>
                                    <Button hidden={checkDefaultFolder(currentSelect?currentSelect.name:"")} icon={<MdDelete />}>Xóa thư mục</Button>
                                    <Button hidden={checkDefaultFolder(currentSelect?currentSelect.name:"")} icon={<LuPencilLine />}>Đổi tên  thư mục</Button>
                                </Space>
                                <Space size={"middle"}>
                                    <Tooltip className="position-relative" title={"Chi tiết"}>
                                        <Button onClick={showDrawer} icon={<AiOutlineExclamationCircle />}></Button>
                                    </Tooltip>
                                    <Tooltip title={"Tìm kiếm tên thư mục hoặc tệp"}>
                                        <Button icon={<CiSearch />}></Button>
                                    </Tooltip>
                                    <FileUpload />
                                </Space>
                            </Flex>
                        </Header>
                        <Content>Content</Content>
                        <Footer >Footer</Footer>

                    </Layout>
                </Layout>
                <Drawer closable={false} getContainer={false} title="Chi tiết" onClose={onClose} open={isOpen}>
                   <p>hehe</p>
                </Drawer>
            </Modal>
        </div>
    )
}
export default FileManager