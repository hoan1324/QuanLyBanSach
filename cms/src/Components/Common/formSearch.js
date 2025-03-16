import { Form, Input, Select, DatePicker, Flex, Button, Tooltip } from "antd";
import { SearchOutlined } from '@ant-design/icons';

import { convertDate, convertDateRangeToObject } from "../../CommonHelper/utils/helper/dateHelper";
import constantType from "../../CommonHelper/Constant/constantType";

function FilterInput({ filter }) {
  return (
    <Form.Item className="my-0"
      name={filter?.filterFields.join(",")}
    >
      {filter.filterType === constantType.filterType.textBox && (
        <Input placeholder={filter.title} />
      )}

      {filter.filterType === constantType.filterType.selectBox && (
        <Select
          className="w-100"
          placeholder={filter?.title}
          options={
            filter?.options
              ? filter.options.map((element) => ({
                value: element.id,
                label: element.name,
              }))
              : []
          }
        />
      )}

      {filter.filterType === constantType.filterType.dateTimePicker && (
        <DatePicker
          placeholder={filter?.title}
          format="DD/MM/YYYY"
          className="w-100"
        />
      )}

      {filter.filterType === constantType.filterType.rangeDatePicker && (
        <DatePicker.RangePicker placeholder={["Từ ngày", "Đến ngày"]} />
      )}
    </Form.Item>
  );
}

function FormSearch({ filters, handleSearch }) {
  const [form] = Form.useForm();

  const assignValue = (values) => {
    return filters.map((element) => {
      const value = values[element.filterFields.join(",")];

      if (value === undefined || value === null || (typeof (value) === "string" && value?.trim().length === 0)) return null; // Bỏ qua nếu không có dữ liệu

      if (element?.filterType === constantType.filterType.dateTimePicker) {
        values[element.filterFields.join(",")] = convertDate(value);
      }

      if (element?.filterType === constantType.filterType.rangeDatePicker) {
        values[element.filterFields.join(",")] = convertDateRangeToObject(value[0], value[1]);
      }

      return {
        filterFields: element.filterFields,
        value: values[element.filterFields.join(",")],
        condition: element.condition,
        filterType: element.filterType
      };
    }).filter(item => item !== null); // Loại bỏ các giá trị null
  };

  const onFinishSearch = (values) => {
    const filter = assignValue(values);
    handleSearch(filter);
    form.resetFields()
  };

  const handleSubmit = async () => {
    try {
      await form.validateFields();
      const values = form.getFieldsValue(true);
      const hasValue = Object.values(values).some(val => val !== undefined && val !== "");

      if (!hasValue) {
        form.setFields([
          {
            name: filters[0]?.filterFields.join(","),
            errors: ["Vui lòng nhập ít nhất một trường!"],
          },
        ]);
        return;
      }

      form.submit()
    } catch (error) {
      console.log("Lỗi xác thực:", error);
    }
  };

  return (
    <div className="mb-3">
      <Form onFinish={onFinishSearch} form={form}>
        <Flex gap="small" justify="end" align="center" wrap>
          {filters.map((element, index) => (
            <FilterInput key={index} filter={element} />
          ))}
          <Tooltip title="Tìm kiếm">
            <Button
              shape="circle"
              icon={<SearchOutlined />}
              onClick={handleSubmit}
            />
          </Tooltip>
        </Flex>
      </Form>
    </div>
  );
}
export default FormSearch