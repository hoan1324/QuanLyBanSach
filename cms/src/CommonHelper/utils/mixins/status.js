import vnConst from "../../../i18vn/vi-VN";
import { blue,red,green} from "@ant-design/colors";

function UseStatusMixin(){
    const staffStatus=[
        {id:0,name:vnConst.currentlyEmployed,color:blue.primary},
        {id:1,name:vnConst.resigned,color:red.primary}
    ]
    const gender=[
        {id:0,name:"Nam",color:blue.primary},
        {id:1,name:"Nữ",color:green.primary}
    ]
    return {
        staffStatus,
        gender
    }
}
export default UseStatusMixin