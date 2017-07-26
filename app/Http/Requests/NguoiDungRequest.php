<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class NguoiDungRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    public function rules()
    {
        return [
            'name'         =>'required|min:5',
            'email'        =>'required|email|unique:users,email,'.$this->id,
            'password'     => 'required|min:5|max:30',
            'passwordagain'=> 'required|same:password'
        ];
    }
    public function messages()
    {
        return [
            'name.required'             => 'Bạn chưa nhập tên người dùng',
            'name.min'              =>'Tên người dùng ít nhất phải có 5 ký tự',
            'email.required'        =>'Bạn chưa nhập Email',
            'email.email'           =>'Bạn chưa nhập đúng định dạng Email',
            'email.unique'          => 'Email đã tồn tại trong Cơ sỡ dữ liệu',
            'password.required'     =>'Bạn chưa nhập Mật khẩu',
            'password.min'          =>'Mật khẩu phải có ít nhất 5 ký tự',
            'password.max'          =>'Mật khẩu tối đa chỉ được 30 ký tự',
            'passwordagain.required'=>'Bạn chưa nhập lại mật khẩu',
            'passwordagain.same'    =>'Mật khẩu nhập lại chưa khớp'
        ];
    }
}
