import { Form, Input, InputNumber } from "antd";
import TextArea from "antd/es/input/TextArea";

import services from "../../boot/services";
import constantType from "../../CommonHelper/Constant/constantType";
import jobColumn from "../../Components/TableColumn/jobColumns";
import TemplatePage from "../../Components/Common/templatePage";

function Job() {
  return (
    <TemplatePage config={config}>
      <Form.Item label="Tên công việc" name="name" rules={[{ required: true, message: "Vui lòng nhập tên công việc" }]}>
        <Input placeholder="Nhập tên công việc" className="w-100"></Input>
      </Form.Item>
      <div className="row">
        <Form.Item className="col-md-6" label="Lương tối thiểu (VNĐ)" name="salaryMin"
          rules={[
            { required: true, message: 'Vui lòng nhập mức lương!' },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (value && getFieldValue('salaryMin') > getFieldValue('salaryMax')) {
                  return Promise.reject('Lương tối thiểu không được lớn hơn lương tối đa!');
                }
                return Promise.resolve();
              },
            }),
          ]}
        >
          <InputNumber placeholder="Nhập mức lương tối thiểu" className="w-100" min={0} />
        </Form.Item>
        <Form.Item className="col-md-6" label="Lương tối đa (VNĐ)" name="salaryMax"
          rules={[
            { required: true, message: 'Vui lòng nhập mức lương tối đa!' },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (value && getFieldValue('salaryMin') > getFieldValue('salaryMax')) {
                  return Promise.reject('Lương tối thiểu không được lớn hơn lương tối đa!');
                }
                return Promise.resolve();
              },
            }),
          ]}>
          <InputNumber placeholder="Nhập mức lương tối đa" style={{ width: '100%' }} min={0} />
        </Form.Item>
      </div>
      <Form.Item label="Mô tả công việc" name="description" >
        <TextArea placeholder="Nhập mô tả công việc"
          autoSize={{
            minRows: 4,
            maxRows: 6,
          }}></TextArea>
      </Form.Item>
    </TemplatePage>
  );
}
const dataSource = (data, page, size) => {

  return data.map((element, index) => ({
    stt: (page - 1) * size + index + 1,
    key: element.id,
    name: element.name,
    salaryMin: element.salaryMin,
    salaryMax: element.salaryMax,
    description: element.description
  }));
};
const config = {
  title: "Quản lý công việc",
  modalName: "công việc",
  service: services.jobService,
  dataSource: dataSource,
  column: jobColumn,
  filters: [
    {
      filterFields: ["Name", "Description"],
      value: null,
      condition: constantType.filterCondition.contain,
      filterType: constantType.filterType.textBox,
      title: "Tìm kiếm tên ,mô tả công việc..."
    }
  ]
}
export default Job;
