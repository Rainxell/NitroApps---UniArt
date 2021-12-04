import React from "react";
import { AllCheckerCheckbox, Checkbox, CheckboxGroup } from '@createnl/grouped-checkboxes';
import CheckBoxIcon from '@mui/icons-material/CheckBox';
import CheckBoxOutlineBlankIcon from '@mui/icons-material/CheckBoxOutlineBlank';

interface checkbox {
  checked?: boolean,
  disabled?: boolean,
  value?: string | number | readonly string[] | undefined
  label?: string
};

function CheckParentAll (props:{
  id:string,
  list:Array<checkbox>,
  onchange?: string,
}) {
  
  let checkboxes_vals = Array<checkbox>(props.list.length);
  props.list.forEach(c => {
    checkboxes_vals.push({
      checked:false,
      disabled:false,
      value: c.value+'',
      label: c.label
    });
  });

  const changeCheckAll = (checked:boolean) => {
    let cp = document.querySelector<HTMLInputElement>(`#${props.id} #all :nth-child(1)`);
    let cT = document.querySelector<SVGElement>(`#${props.id} #all :nth-child(2)`);
    let cF = document.querySelector<SVGElement>(`#${props.id} #all :nth-child(3)`);
    //console.log(cT);
    if (checked) {
      if (cT !== null){ cT.style.display = 'inline-block'; }
      if (cF !== null){ cF.style.display = 'none'; }
    } else {
      if (cF !== null){ cF.style.display = 'inline-block'; }
      if (cT !== null){ cT.style.display = 'none'; }
    }
    if (cp !== null) { cp.checked = checked; }
  };
  
  const onCheckAll = (event: React.ChangeEvent<HTMLInputElement>) => {
    changeCheckAll(event.target.checked);
  };
  const allCheked = (checkboxes:checkbox[]) => {
    for (let i = 0; i < checkboxes.length; i++) {
      if(checkboxes[i].checked === false) { return false; }
    }
    return true;
  }

  const onCheckboxChange = (checkboxes:checkbox[]) => {
    //console.log(checkboxes);
    checkboxes.map( (c)=>{
      let idc = `#${props.id} #cb-${c.value}`;
      let cT = document.querySelector<SVGElement>(`${idc} :nth-child(2)`);
      let cF = document.querySelector<SVGElement>(`${idc} :nth-child(3)`);
      if (c.checked) {
        if (cT !== null){ cT.style.display = 'inline-block'; }
        if (cF !== null){ cF.style.display = 'none'; }
        if (allCheked(checkboxes)){ changeCheckAll(true); }
      } else {
        if (cF !== null){ cF.style.display = 'inline-block'; }
        if (cT !== null){ cT.style.display = 'none'; }
        changeCheckAll(false);
      }
    } );
  }

  return (
    <div id={props.id} className={"check-all-group"}>
    <CheckboxGroup onChange={onCheckboxChange} defaultChecked>
      <label id={'all'}>
      <AllCheckerCheckbox onChange={onCheckAll} style={{display:"none"}}/>
        <CheckBoxIcon color="primary"/>
        <CheckBoxOutlineBlankIcon color="primary" style={{display:'none'}}/>Todo 
      </label>
      { checkboxes_vals.map( (cb,i)=>{
          return (
            <label id={('cb-'+cb.value)}>
              <Checkbox value={cb.value}  style={{display:'none'}}/>
              <CheckBoxIcon color="primary"/>
              <CheckBoxOutlineBlankIcon color="primary"/>
              {cb.label}
            </label>
          );
        } ) }
    </CheckboxGroup>
    </div>
  );
};

export default CheckParentAll;