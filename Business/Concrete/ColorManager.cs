using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Messages.ColorNonFound);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Messages.ColorNonFound);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
