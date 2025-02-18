import { Space, Popconfirm, Tag } from "antd";
import { BiCommentDetail } from "react-icons/bi";
import { MdDeleteForever } from "react-icons/md";
import { FaRegEdit } from "react-icons/fa";
import { Tooltip } from "antd"


const actionColumn = ({ handleEdit, handleDelete, handleDetail, title }) => ({
    title: "Chức năng",
    dataIndex: "action",
    key: "action",
    align: 'center',
    width: 170,
    render: (_, record) => (
        <Space size="middle">
            <Tooltip title="Xem chi tiết">
                <BiCommentDetail style={{ color: 'blue', cursor: 'pointer', fontSize: '20px' }} onClick={() => handleDetail(record.key)} />
            </Tooltip>
            <Tooltip title="Chỉnh sửa">
                <FaRegEdit style={{ color: 'orange', cursor: 'pointer', fontSize: '20px' }} onClick={() => handleEdit(record.key)} />
            </Tooltip>
            <Popconfirm title={`Xác nhận xóa ${title} này`} onConfirm={() => handleDelete(record.key)} okText="Xác nhận" cancelText="Hủy">
                <Tooltip title="Xóa">
                    <MdDeleteForever style={{ color: 'red', cursor: 'pointer', fontSize: '20px' }} />
                </Tooltip>
            </Popconfirm>
        </Space>
    ),
});
export default actionColumn