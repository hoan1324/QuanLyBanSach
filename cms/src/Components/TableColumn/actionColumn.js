import { Space, Popconfirm } from "antd";
import { BiCommentDetail } from "react-icons/bi";
import { MdDeleteForever } from "react-icons/md";
import { FaRegEdit } from "react-icons/fa";
import { Tooltip } from "antd";

const actionColumn = ({
  handleEdit,
  handleDelete,
  handleDetail,
  title,
  permissionDetail,
  permissionEdit,
  permissionDelete, // sửa lại tên biến
}) => ({
  title: "Chức năng",
  dataIndex: "action",
  key: "action",
  align: "center",
  width: 170,
  render: (_, record) => (
    <Space size="middle">
      {permissionDetail && (
        <Tooltip title="Xem chi tiết">
          <BiCommentDetail
            style={{ color: "blue", cursor: "pointer", fontSize: "20px" }}
            onClick={() => handleDetail(record.key)}
          />
        </Tooltip>
      )}
      {permissionEdit && (
        <Tooltip title="Chỉnh sửa">
          <FaRegEdit
            style={{ color: "orange", cursor: "pointer", fontSize: "20px" }}
            onClick={() => handleEdit(record.key)}
          />
        </Tooltip>
      )}
      {permissionDelete && (
        <Popconfirm
          title={`Xác nhận xóa ${title} này`}
          onConfirm={() => handleDelete(record.key)}
          okText="Xác nhận"
          cancelText="Hủy"
        >
          <Tooltip title="Xóa">
            <MdDeleteForever
              style={{ color: "red", cursor: "pointer", fontSize: "20px" }}
            />
          </Tooltip>
        </Popconfirm>
      )}
    </Space>
  ),
});
export default actionColumn;
