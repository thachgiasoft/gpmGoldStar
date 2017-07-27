<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class cafe_DanhMucRequest extends FormRequest
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
            'tendanhmuc' =>'required|min:5|unique:cafe_danhmuc,tendanhmuc,'.$this->id,
        ];
    }
    public function messages()
    {
        return [
            'tendanhmuc.required' => 'Vui lòng nhập tên danh mục cafe',
            'tendanhmuc.min'      =>'Tên danh mục cafe ít nhất phải có 5 ký tự',
            'tendanhmuc.unique'   =>'Danh mục cafe đã tồn tại',
        ];
    }
}
