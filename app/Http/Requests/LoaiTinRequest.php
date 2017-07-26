<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class LoaiTinRequest extends FormRequest
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
            'TenLoai'=>'required|unique:loaitin,TenLoai,'.$this->id,
            'IDNhomLoaiTin'=>'required'
        ];
    }
    public function messages()
    {
        return [
            'TenLoai.required'=>'Bạn chưa nhập tên loại tin',
            'TenLoai.unique'  =>'Tên loại tin đã tồn tại',
            'IDNhomLoaiTin.required'=>'Bạn chưa chọn thể loại'
        ];
    }
}
