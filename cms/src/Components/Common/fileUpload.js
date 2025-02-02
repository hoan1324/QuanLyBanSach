import { Button, Upload } from "antd"
import { UploadOutlined} from '@ant-design/icons' 

function FileUpload(){
return(
    <Upload >
        <Button icon={<UploadOutlined />}>Tải tệp lên</Button>
    </Upload>
)
}
export default FileUpload