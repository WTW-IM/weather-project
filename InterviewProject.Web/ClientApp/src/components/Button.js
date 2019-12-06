import React from 'react'
import { useSafeState } from '../hooks/useSafeState'

export function Button(props) {
    const [running, setRunning] = useSafeState(false);
    const { runningDisplay, onClick, children, className, ...otherProps } = props;

    const clickHandler = e => {
        e.preventDefault && e.preventDefault();

        if (!running) {
            setRunning(true);

            const startClickBehavior = async () => {
                try {
                    await onClick();
                }
                finally {
                    setRunning(false);
                }
            };
            startClickBehavior();
        }

        return false;
    }

    return <button
        className={`${className}${running ? " disabled" : ""}`}
        {...otherProps}
        onClick={clickHandler}>
        {running ? (runningDisplay || children) : children}
    </button>;
}