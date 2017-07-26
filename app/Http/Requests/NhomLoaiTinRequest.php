<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class NhomLoaiTinRequest extends FormRequest
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
            'TenNhom'=>'required|min:5|unique:nhomloaitin,TenNhom,'.$this->id,
        ];
    }

    public function messages()
    {
        return [
            'TenNhom.required'=>'Bạn chưa nhập tên thể loại',
            'TenNhom.min'     =>'Tên thể loại phải ít nhất 5 ký tự',
            'TenNhom.unique'  =>'Tên thể loại đã tồn tại'
        ];
    }
}
