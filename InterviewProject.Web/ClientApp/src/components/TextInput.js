import React, { useRef, useEffect } from 'react'

export function TextInput(props) {
    const { autofocus, value, onChange, ...otherProps } = props;
    const onTextChange = event => onChange(event && event.target && event.target.value);
    const theInput = useRef(null);

    useEffect(() => autofocus && theInput && theInput.current && theInput.current.focus(), [autofocus]);

    return <input
        className="form-control"
        {...otherProps}
        ref={theInput}
        type="text"
        value={value || ""}
        onChange={onTextChange} />
}