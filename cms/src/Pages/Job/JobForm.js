import { Form, Input, InputNumber } from "antd";
import TextArea from "antd/es/input/TextArea";

function JobForm() {
  const validateSalaryRange = (getFieldValue) => (_, value) => {
    const min = getFieldValue("salaryMin");
    const max = getFieldValue("salaryMax");

    if (min && max && min > max) {
      return Promise.reject("Lương tối thiểu không được lớn hơn lương tối đa!");
    }
    return Promise.resolve();
  };

  return (
    <>
      <Form.Item
        label="Tên công việc"
        name="name"
        rules={[{ required: true, message: "Vui lòng nhập tên công việc" }]}
      >
        <Input placeholder="Nhập tên công việc" className="w-100" />
      </Form.Item>
      <div className="row">
        <Form.Item
          className="col-md-6"
          label="Lương tối thiểu (VNĐ)"
          name="salaryMin"
          rules={[
            { required: true, message: "Vui lòng nhập mức lương!" },
            ({ getFieldValue }) => ({
              validator: validateSalaryRange(getFieldValue),
            }),
          ]}
        >
          <InputNumber
            placeholder="Nhập mức lương tối thiểu"
            className="w-100"
            min={0}
          />
        </Form.Item>
        <Form.Item
          className="col-md-6"
          label="Lương tối đa (VNĐ)"
          name="salaryMax"
          rules={[
            { required: true, message: "Vui lòng nhập mức lương tối đa!" },
            ({ getFieldValue }) => ({
              validator: validateSalaryRange(getFieldValue),
            }),
          ]}
        >
          <InputNumber
            placeholder="Nhập mức lương tối đa"
            style={{ width: "100%" }}
            min={0}
          />
        </Form.Item>
      </div>
      <Form.Item label="Mô tả công việc" name="description">
        <TextArea
          placeholder="Nhập mô tả công việc"
          autoSize={{ minRows: 4, maxRows: 6 }}
        />
      </Form.Item>
    </>
  );
}

export default JobForm;
