import { Color } from "antd/es/color-picker";

function UseMethodMixin() {
  const PermissionMethodEnum = [
    { id: 1, name: "Create", color: Color.green },
    { id: 2, name: "Read", color: Color.blue },
    { id: 3, name: "Update", color: Color.orange },
    { id: 4, name: "Delete", color: Color.red },
  ];
  return {
    PermissionMethodEnum,
  };
}
export default UseMethodMixin;
