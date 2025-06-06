import { Form, Input, InputNumber } from "antd";
import TextArea from "antd/es/input/TextArea";

function CategoryForm() {
  return (
    <>
      <Form.Item
        label="Tên danh mục"
        name="name"
        rules={[{ required: true, message: "Vui lòng nhập tên danh mục" }]}
      >
        <Input placeholder="Nhập tên danh mục" className="w-100" />
      </Form.Item>

      <Form.Item label="Mô tả danh mục" name="description">
        <TextArea
          placeholder="Nhập mô tả danh mục"
          autoSize={{ minRows: 4, maxRows: 6 }}
        />
      </Form.Item>
    </>
  );
}

export default CategoryForm;
