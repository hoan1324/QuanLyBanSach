import { Button, Modal, Layout, Menu, Flex, Space, Tooltip, Drawer } from "antd";
import { useState } from "react";
import { AiOutlineFolderAdd, AiOutlineExclamationCircle } from "react-icons/ai";
import { MdDelete } from "react-icons/md";
import { CiSearch } from "react-icons/ci";
import { LuPencilLine } from "react-icons/lu";
import {
    MenuFoldOutlined,
    MenuUnfoldOutlined,
    UploadOutlined,
    UserOutlined,
    VideoCameraOutlined,
} from '@ant-design/icons';
import FileUpload from "./fileUpload";
const { Header, Footer, Sider, Content } = Layout;

function FileManager() {
    const [open, setOpen] = useState(false)
    const [collapsed, setCollapsed] = useState(false);
    const [isOpen, setIsOpen] = useState(false)
    const showDrawer = () => {
        setIsOpen(true);
    };
    const onClose = () => {
        setIsOpen(false);
    };

    return (
        <div>
            <Button onClick={() => setOpen(true)}> Mở</Button>
            <Modal className="position-relative overflow-hidden" title={"Quản lý file"} centered width={1100} onCancel={() => setOpen(false)} open={open} okText={"Chọn"}>
                <Layout className="bg-white rounded" style={{ minHeight: '800px' }}>
                    <Sider className="bg-white" trigger={null} collapsible collapsed={collapsed} onMouseOut={() => setCollapsed(true)} onMouseOver={() => setCollapsed(false)} onCollapse={(value) => setCollapsed(value)} width="25%" >
                        <Menu
                            theme="light"
                            mode="inline"
                            defaultSelectedKeys={['1']}
                            items={[
                                {
                                    key: '1',
                                    icon: <UserOutlined />,
                                    label: 'nav 1',
                                },
                                {
                                    key: '2',
                                    icon: <VideoCameraOutlined />,
                                    label: 'nav 2',
                                },
                                {
                                    key: '3',
                                    icon: <UploadOutlined />,
                                    label: 'nav 3',
                                },
                            ]}
                        />
                    </Sider>
                    <Layout>
                        <Header className="bg-white px-2" >
                            <Flex justify="space-between" wrap>
                                <Space size={"middle"}>
                                    <Button icon={<AiOutlineFolderAdd />}>Thêm thư mục</Button>
                                    <Button icon={<MdDelete />}>Xóa thư mục</Button>
                                    <Button icon={<LuPencilLine />}>Đổi tên  thư mục</Button>
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
                    <p>Some contents...</p>
                    <p>Some contents...</p>
                    <p>Some contents...</p>
                </Drawer>
            </Modal>
        </div>
    )
}
export default FileManager