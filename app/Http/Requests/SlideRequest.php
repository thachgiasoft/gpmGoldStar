<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class SlideRequest extends FormRequest
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
            'TenHinh' =>'required|min:5',
            'NoiDung' =>'required',
            'Hinh'    =>'required',
        ];
    }
    public function messages()
    {
        return [
            'TenHinh.required'      => 'Bạn chưa nhập tên hình',
            'TenHinh.min'           =>'Tên hình ít nhất phải có 5 ký tự',
            'NoiDung.required'      =>'Bạn chưa nhập Nội dung',
            'Hinh.required'         =>'Bạn chưa chọn hình',
        ];
    }
}
