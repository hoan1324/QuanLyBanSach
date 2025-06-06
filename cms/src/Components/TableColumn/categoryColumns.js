import { commonColumn } from "../../CommonHelper/Constant/commonColumn";
import actionColumn from "./actionColumn";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import useHasPermission from "../../hooks/useHasPermission";

const CategoryColumn = ({ handleEdit, handleDelete, handleDetail }) => {
  const permissionDetail = useHasPermission("Category-GetByIdAsync");
  const permissionEdit = useHasPermission("Category-UpdateAsync");
  const permissionDelete = useHasPermission("Category-DeleteAsync");

  return [
    ...commonColumn,
    {
      title: "Tên danh mục",
      dataIndex: "name",
      key: "name",
      align: "center",
    },

    {
      title: "Mô tả danh mục",
      dataIndex: "description",
      key: "description",
      align: "center",
    },

    actionColumn({
      handleEdit,
      handleDelete,
      handleDetail,
      title: "danh mục",
      permissionDetail,
      permissionEdit,
      permissionDelete,
    }),
  ];
};
export default CategoryColumn;
