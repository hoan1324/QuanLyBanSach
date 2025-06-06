import { commonColumn } from "../../CommonHelper/Constant/commonColumn";
import actionColumn from "./actionColumn";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import useHasPermission from "../../hooks/useHasPermission";

const JobColumn = ({ handleEdit, handleDelete, handleDetail }) => {
  const permissionDetail = useHasPermission("Job-GetByIdAsync");
  const permissionEdit = useHasPermission("Job-UpdateAsync");
  const permissionDelete = useHasPermission("Job-DeleteAsync");

  return [
    ...commonColumn,
    {
      title: "Tên công việc",
      dataIndex: "name",
      key: "name",
      align: "center",
    },

    {
      title: "Mô tả công việc",
      dataIndex: "description",
      key: "description",
      align: "center",
    },

    actionColumn({
      handleEdit,
      handleDelete,
      handleDetail,
      title: "công việc",
      permissionDetail,
      permissionEdit,
      permissionDelete,
    }),
  ];
};
export default JobColumn;
