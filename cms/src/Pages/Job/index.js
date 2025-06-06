import JobForm from "./JobForm";
import JobDetail from "./JobDetail";
import services from "../../boot/services";
import constantType from "../../CommonHelper/Constant/constantType";
import JobColumn from "../../Components/TableColumn/jobColumns";
import TemplatePage from "../../Components/Common/templatePage";

const dataSource = (data, page, size) => {
  return data.map((element, index) => ({
    stt: (page - 1) * size + index + 1,
    key: element.id,
    name: element.name,
    description: element.description,
  }));
};
const config = {
  title: "Quản lý công việc",
  modalName: "công việc",
  service: services.jobService,
  dataSource: dataSource,
  column: JobColumn,
  orderByColumn: "CreatedDate",
  permissionController: "Job",
  filters: [
    {
      filterFields: ["Name", "Description"],
      value: null,
      condition: constantType.filterCondition.contain,
      filterType: constantType.filterType.textBox,
      title: "Tìm kiếm tên ,mô tả công việc...",
    },
  ],
};

function Job() {
  return (
    <TemplatePage ModalForm={JobForm} ModalDetail={JobDetail} config={config} />
  );
}

export default Job;
