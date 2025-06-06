import {
  Form,
  Input,
  Select,
  DatePicker,
  Flex,
  Button,
  Tooltip,
  message,
} from "antd";
import { useState } from "react";
import { ReloadOutlined } from "@ant-design/icons";
import { SearchOutlined } from "@ant-design/icons";
import { useCallback } from "react";
import {
  convertDate,
  convertDateRangeToObject,
} from "../../CommonHelper/utils/helper/dateHelper";
import constantType from "../../CommonHelper/Constant/constantType";
import useFilterLogic from "../../hooks/useFilterLogic";

function FilterInput({ filter }) {
  return (
    <Form.Item className="my-0" name={filter?.filterFields.join(",")}>
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
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleDebouncedOk = async () => {
    try {
      await form.validateFields();
      const values = form.getFieldsValue(true);

      if (!hasValue(values)) {
        message.warning("Vui lòng nhập ít nhất một trường để tìm kiếm.");
        return;
      }

      form.submit();
    } catch (error) {
      console.log("Lỗi xác thực:", error);
    }
  };

  const { assignValue, hasValue } = useFilterLogic(filters);

  const onFinishSearch = (values) => {
    const filter = assignValue(values);
    console.log("filter");
    console.log(JSON.stringify(filter));
    handleSearch(JSON.stringify(filter));
    form.resetFields();
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
              onClick={handleDebouncedOk}
            />
          </Tooltip>

          <Tooltip title="Đặt lại">
            <Button
              type="default"
              shape="circle"
              icon={<ReloadOutlined />} // import { ReloadOutlined } from "@ant-design/icons";
              onClick={() => {
                form.resetFields();
              }}
            />
          </Tooltip>
        </Flex>
      </Form>
    </div>
  );
}
export default FormSearch;
