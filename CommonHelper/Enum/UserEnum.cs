using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Enum
{
	public enum UserStatusEnum
	{
		Active = 1,
		Locked = 2,
	}
	public enum GenderEnum
	{
		Male = 0,
		Female = 1,
	}
	public enum UserLoginSatus
	{
		Ok = 1,
		WrongPass = 2,
		Locked = 3,
	}
	public enum RefreshTokenEnum
	{
		TokenEmpty = 0,
		Ok = 1,
		NotValid = 2,
		NotFound = 3,
		RefreshTokenExpire = 4,
	}
}
