import { Tag, Image } from "antd";

import actionColumn from "./actionColumn";
import { formatDateVn } from "../../CommonHelper/utils/helper/dateHelper";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import services from "../../boot/services";
import EntityName from "../Common/entityName";
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
import { commonColumn } from "../../CommonHelper/Constant/commonColumn";
import useHasPermission from "../../hooks/useHasPermission";
import {
  statusBadge,
  statusStyle,
} from "../../CommonHelper/utils/helper/statusHelper";
const StaffColumn = ({ handleEdit, handleDelete, handleDetail }) => {
  const permissionDetail = useHasPermission("Staff-GetByIdAsync");
  const permissionEdit = useHasPermission("Staff-UpdateAsync");
  const permissionDelete = useHasPermission("Staff-DeleteAsync");

  return [
    ...commonColumn,
    {
      title: "Tên nhân viên",
      dataIndex: "name",
      key: "name",
      align: "center",
    },
    {
      title: "Ngày sinh",
      dataIndex: "dateOfBirth",
      key: "dateOfBirth",
      align: "center",
      render: (date) => formatDateVn(date),
    },
    {
      title: "Địa chỉ",
      dataIndex: "address",
      key: "address",
      align: "center",
    },
    {
      title: "Số điện thoại",
      dataIndex: "phoneNumber",
      key: "phoneNumber",
      align: "center",
    },
    {
      title: "Email",
      dataIndex: "email",
      key: "email",
      align: "center",
    },
    {
      title: "Ngày bắt đầu",
      dataIndex: "startDate",
      key: "startDate",
      align: "center",
      render: (date) => formatDateVn(date),
    },

    {
      title: "Giới tính",
      dataIndex: "gender",
      key: "gender",
      align: "center",
      render: (_, record) => (
        <Tag color={statusStyle(UseStatusMixin().gender, record.gender)}>
          {statusBadge(UseStatusMixin().gender, record.gender)}
        </Tag>
      ),
    },
    {
      title: "Trạng thái",
      dataIndex: "status",
      key: "status",
      align: "center",
      render: (_, record) => (
        <Tag color={statusStyle(UseStatusMixin().staffStatus, record.status)}>
          {statusBadge(UseStatusMixin().staffStatus, record.status)}
        </Tag>
      ),
    },

    actionColumn({
      handleEdit,
      handleDelete,
      handleDetail,
      title: "nhân viên",
      permissionDetail,
      permissionEdit,
      permissionDelete,
    }),
  ];
};
export default StaffColumn;
