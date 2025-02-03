import vnConst from "../../../i18vn/vi-VN";
import { blue,red,green} from "@ant-design/colors";

function UseStatusMixin(){
    const staffStatus=[
        {id:0,name:vnConst.currentlyEmployed,color:blue.primary},
        {id:1,name:vnConst.resigned,color:red.primary}
    ]
    const gender=[
        {id:0,name:vnConst.male,color:blue.primary},
        {id:1,name:vnConst.female,color:green.primary}
    ]
    const commonStatus=[
       {id:0,name:vnConst.active},
       {id:1,name:vnConst.suspend}
    ]
    return {
        staffStatus,
        gender,
        commonStatus
    }
}
export default UseStatusMixin