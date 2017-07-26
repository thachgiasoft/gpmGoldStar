<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class TinTucRequest extends FormRequest
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
            'TieuDe'   =>'required|min:3|unique:tintuc,TieuDe,'.$this->id,
            'IDLoaiTin'=>'required',
            'TomTat'   =>'required',
            'NoiDung'  =>'required',
        ];
    }
    public function messages()
    {
        return [
            'TieuDe.required'   =>'Bạn chưa nhập tiêu đề tin tức',
            'TieuDe.min'        =>'Tiêu đề tin tức phải lớn hơn 5 ký tự',
            'TieuDe.unique'     =>'Tiêu đề tin tức quy định đã tồn tại',
            'IDLoaiTin.required'=>'Bạn chưa chọn Loại tin',
            'TomTat.required'   =>'Bạn chưa nhập tóm tắt',
            'NoiDung.required'  =>'Bạn chưa nhập nội dung',
        ];
    }
}
