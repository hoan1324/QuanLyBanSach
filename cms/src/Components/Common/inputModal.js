import { Modal } from "antd";
import { useState } from "react";

function InputModal({
  title,
  isOpen,
  handleClose,
  handleOk,
  children,
  width,
  disabled,
}) {
  const [isSubmitting, setIsSubmitting] = useState(false);

  console.log("InputModal dis:", disabled);

  const handleDebouncedOk = async () => {
    if (isSubmitting) return; // Ngăn việc nhấn lại
    setIsSubmitting(true);
    try {
      await handleOk(); // Gọi hàm handleOk
    } finally {
      setIsSubmitting(false); // Reset trạng thái sau khi hoàn thành
    }
  };

  return (
    <Modal
      title={title}
      onClose={handleClose}
      open={isOpen}
      onOk={handleDebouncedOk}
      onCancel={handleClose}
      okText="Xác nhận"
      cancelText="Hủy"
      centered
      width={width}
      footer={disabled ? null : undefined} // Ẩn footer nếu disabled là true
      destroyOnClose={true} // Đóng modal sẽ reset lại trạng thái
      maskClosable={false} // Ngăn việc đóng modal khi click ra ngoài
      confirmLoading={isSubmitting} // Hiển thị trạng thái loading trên nút OK
    >
      {children}
    </Modal>
  );
}

export default InputModal;
