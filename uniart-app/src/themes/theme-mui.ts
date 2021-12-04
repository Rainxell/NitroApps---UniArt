import { createTheme } from '@mui/material/styles';

declare module '@mui/material/styles' {
  interface Theme {
    status: {
      danger: string;
    };
  }
  // allow configuration using `createTheme`
  interface ThemeOptions {
    status?: {
      danger?: string;
    };
  }
}

const typos = [
  '-apple-system',
  'BlinkMacSystemFont',
  'Roboto',
  '"Helvetica Neue"',
  'Calibri',
  'sans-serif',
  '"Apple Color Emoji"',
  '"Segoe UI Emoji"',
  '"Segoe UI Symbol"',
].join(',');

const whites = {
  dark: '#DEEAF4',
  main: '#F2F6F9',
  light: '#FFF',
};

const blacks = {
  dark: '#000',
  main: '#002845',
  light: '#798F9F',
};


const themeMui = createTheme({
  palette: {
    primary: {
      light: '#ff7695',
      main: '#ea4067',
      dark: '#b2003d',
      contrastText: '#fff',
    },
    secondary: {
      light: '#76fdfa',
      main: '#37C9C7',
      dark: '#009896',
      contrastText: blacks.main,
    },
    info: {
      main: '#FFD073',
      contrastText: blacks.main,
    },
    error: {
      main: "#000",
      contrastText: "#FFF",
    }
  },
  status: {
    danger: blacks.main,
  },
  typography: {
    fontFamily: '"Maven Pro",' + typos,
    fontSize: 12,
    h1: {
      textAlign: "center" ,
      marginBottom: "1rem",
      textTransform: "uppercase",
      fontWeight: "bold",
      fontSize: "4rem",
    },
    h2: { fontSize: '3rem', },
    h3: { fontSize: '2rem', },
    h4: { fontSize: '1.5rem', },
    h5: { fontSize: '1.15rem', },
    h6: { fontSize: '0.9rem', },
  },
  components: {
    MuiTypography:{
      styleOverrides: {
        root: {
          lineHeight: "1em",
        }
      }
    },
    MuiListItem: {
      defaultProps: {
        disablePadding: true,
      },
    },
    MuiListItemIcon: {
      styleOverrides: {
        root: {
          minWidth: '1.5rem',
        },
      },
    },
    MuiAppBar:{
      styleOverrides: {
        root: {
          backgroundColor: whites.main,
          color: blacks.main,
        },
      },
    },
    MuiToolbar: {
      styleOverrides: {
        root: {
          backgroundColor: whites.main,
          color: blacks.main,
          columnGap: "0.5rem",
          rowGap: "0.5rem",
          padding: "0px",
        }
      }
    },
    MuiGrid: {
      styleOverrides: {
        root: {
          justifyContent: "center",
          alignItems: "center",
        }
      }
    },
    MuiContainer: {
      defaultProps: {
        maxWidth: false,
      },
      styleOverrides: {
        root: {
          color: blacks.main,
          padding: "4rem 3rem",
          textAlign: "center",
        }
      }
    },
    MuiButton: {
      styleOverrides: {
        root: {
          fontWeight: "bold",
          paddingLeft: "1rem",
          paddingRight: "1rem",
        }
      }
    },
    MuiLink: {
      defaultProps: {
        underline: "none",
      },
      styleOverrides: {
        root: {
          color: "inherit",
        }
      }
    },
    MuiCardContent: {
      styleOverrides: {
        root: {
          textAlign: "left",
          display: "flex",
          flexFlow: "column",
          rowGap: "1rem",
          color: blacks.main,
        }
      }
    },
    MuiAccordionDetails: {
      styleOverrides: {
        root: {
          display: "flex",
          flexDirection: "column",
          rowGap: "0.5em",
        }
      }
    },
    MuiCheckbox: {
      styleOverrides: {
        root: {
          padding: "0px 0.5em",
        }
      }
    },
    MuiPagination: {
      styleOverrides: {
        ul:{
          justifyContent: "center",
        }
      }
    },
    MuiSelect:{
      defaultProps: {
        variant: 'standard',
      },
      styleOverrides: {
        root: {
          minWidth: "10rem !important",
          textAlign: "left",
        }
      }
    },
    MuiTextField:{
      defaultProps: {
        variant:'standard',
      }
    },
    MuiInput:{
      styleOverrides: {
        root: {
          textAlign: "left",
        }
      }
    },
    MuiFormControl: {
      defaultProps: {
        variant: 'standard',
      }
    }
  },
});

themeMui.typography.h2.fontFamily = themeMui.typography.h3.fontFamily
  = themeMui.typography.h4.fontFamily = themeMui.typography.h5.fontFamily
  = themeMui.typography.h6.fontFamily = '"Palanquin Dark",' + typos;

themeMui.typography.h2.color = themeMui.typography.h3.color
  = themeMui.typography.h4.color = themeMui.typography.h5.color
  = themeMui.typography.h6.color = "inherit";

export {themeMui, whites, blacks};