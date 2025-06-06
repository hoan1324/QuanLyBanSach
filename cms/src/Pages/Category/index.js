import CategoryForm from "./CategoryForm";
import CategoryDetail from "./CategoryDetail";
import services from "../../boot/services";
import constantType from "../../CommonHelper/Constant/constantType";
import TemplatePage from "../../Components/Common/templatePage";
import CategoryColumn from "../../Components/TableColumn/categoryColumns";

const dataSource = (data, page, size) => {
  return data.map((element, index) => ({
    stt: (page - 1) * size + index + 1,
    key: element.id,
    name: element.name,
    description: element.description,
  }));
};
const config = {
  title: "Quản lý danh mục",
  modalName: "danh mục",
  service: services.categoryService,
  dataSource: dataSource,
  column: CategoryColumn,
  orderByColumn: "CreatedDate",
  permissionController: "Category",
  filters: [
    {
      filterFields: ["Name", "Description"],
      value: null,
      condition: constantType.filterCondition.contain,
      filterType: constantType.filterType.textBox,
      title: "Tìm kiếm tên ,mô tả danh mcuj...",
    },
  ],
};

function Category() {
  return (
    <TemplatePage
      ModalForm={CategoryForm}
      ModalDetail={CategoryDetail}
      config={config}
    />
  );
}

export default Category;
