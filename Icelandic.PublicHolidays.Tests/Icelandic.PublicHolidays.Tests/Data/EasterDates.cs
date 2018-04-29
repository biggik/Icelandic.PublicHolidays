﻿using System;
using System.Collections.Generic;

namespace Icelandic.PublicHolidays.Tests.Data
{
    static class EasterDates
    {
        static public IEnumerable<DateTime> Values
        {
            // Values from https://www.census.gov/srd/www/genhol/easter500.txt
            get
            {
                var official = new(int month, int date, int year)[]
                {
                      (4,  2, 1600),
                      (4, 22, 1601),
                      (4,  7, 1602),
                      (3, 30, 1603),
                      (4, 18, 1604),
                      (4, 10, 1605),
                      (3, 26, 1606),
                      (4, 15, 1607),
                      (4,  6, 1608),
                      (4, 19, 1609),
                      (4, 11, 1610),
                      (4,  3, 1611),
                      (4, 22, 1612),
                      (4,  7, 1613),
                      (3, 30, 1614),
                      (4, 19, 1615),
                      (4,  3, 1616),
                      (3, 26, 1617),
                      (4, 15, 1618),
                      (3, 31, 1619),
                      (4, 19, 1620),
                      (4, 11, 1621),
                      (3, 27, 1622),
                      (4, 16, 1623),
                      (4,  7, 1624),
                      (3, 30, 1625),
                      (4, 12, 1626),
                      (4,  4, 1627),
                      (4, 23, 1628),
                      (4, 15, 1629),
                      (3, 31, 1630),
                      (4, 20, 1631),
                      (4, 11, 1632),
                      (3, 27, 1633),
                      (4, 16, 1634),
                      (4,  8, 1635),
                      (3, 23, 1636),
                      (4, 12, 1637),
                      (4,  4, 1638),
                      (4, 24, 1639),
                      (4,  8, 1640),
                      (3, 31, 1641),
                      (4, 20, 1642),
                      (4,  5, 1643),
                      (3, 27, 1644),
                      (4, 16, 1645),
                      (4,  1, 1646),
                      (4, 21, 1647),
                      (4, 12, 1648),
                      (4,  4, 1649),
                      (4, 17, 1650),
                      (4,  9, 1651),
                      (3, 31, 1652),
                      (4, 13, 1653),
                      (4,  5, 1654),
                      (3, 28, 1655),
                      (4, 16, 1656),
                      (4,  1, 1657),
                      (4, 21, 1658),
                      (4, 13, 1659),
                      (3, 28, 1660),
                      (4, 17, 1661),
                      (4,  9, 1662),
                      (3, 25, 1663),
                      (4, 13, 1664),
                      (4,  5, 1665),
                      (4, 25, 1666),
                      (4, 10, 1667),
                      (4,  1, 1668),
                      (4, 21, 1669),
                      (4,  6, 1670),
                      (3, 29, 1671),
                      (4, 17, 1672),
                      (4,  2, 1673),
                      (3, 25, 1674),
                      (4, 14, 1675),
                      (4,  5, 1676),
                      (4, 18, 1677),
                      (4, 10, 1678),
                      (4,  2, 1679),
                      (4, 21, 1680),
                      (4,  6, 1681),
                      (3, 29, 1682),
                      (4, 18, 1683),
                      (4,  2, 1684),
                      (4, 22, 1685),
                      (4, 14, 1686),
                      (3, 30, 1687),
                      (4, 18, 1688),
                      (4, 10, 1689),
                      (3, 26, 1690),
                      (4, 15, 1691),
                      (4,  6, 1692),
                      (3, 22, 1693),
                      (4, 11, 1694),
                      (4,  3, 1695),
                      (4, 22, 1696),
                      (4,  7, 1697),
                      (3, 30, 1698),
                      (4, 19, 1699),
                      (4, 11, 1700),
                      (3, 27, 1701),
                      (4, 16, 1702),
                      (4,  8, 1703),
                      (3, 23, 1704),
                      (4, 12, 1705),
                      (4,  4, 1706),
                      (4, 24, 1707),
                      (4,  8, 1708),
                      (3, 31, 1709),
                      (4, 20, 1710),
                      (4,  5, 1711),
                      (3, 27, 1712),
                      (4, 16, 1713),
                      (4,  1, 1714),
                      (4, 21, 1715),
                      (4, 12, 1716),
                      (3, 28, 1717),
                      (4, 17, 1718),
                      (4,  9, 1719),
                      (3, 31, 1720),
                      (4, 13, 1721),
                      (4,  5, 1722),
                      (3, 28, 1723),
                      (4, 16, 1724),
                      (4,  1, 1725),
                      (4, 21, 1726),
                      (4, 13, 1727),
                      (3, 28, 1728),
                      (4, 17, 1729),
                      (4,  9, 1730),
                      (3, 25, 1731),
                      (4, 13, 1732),
                      (4,  5, 1733),
                      (4, 25, 1734),
                      (4, 10, 1735),
                      (4,  1, 1736),
                      (4, 21, 1737),
                      (4,  6, 1738),
                      (3, 29, 1739),
                      (4, 17, 1740),
                      (4,  2, 1741),
                      (3, 25, 1742),
                      (4, 14, 1743),
                      (4,  5, 1744),
                      (4, 18, 1745),
                      (4, 10, 1746),
                      (4,  2, 1747),
                      (4, 14, 1748),
                      (4,  6, 1749),
                      (3, 29, 1750),
                      (4, 11, 1751),
                      (4,  2, 1752),
                      (4, 22, 1753),
                      (4, 14, 1754),
                      (3, 30, 1755),
                      (4, 18, 1756),
                      (4, 10, 1757),
                      (3, 26, 1758),
                      (4, 15, 1759),
                      (4,  6, 1760),
                      (3, 22, 1761),
                      (4, 11, 1762),
                      (4,  3, 1763),
                      (4, 22, 1764),
                      (4,  7, 1765),
                      (3, 30, 1766),
                      (4, 19, 1767),
                      (4,  3, 1768),
                      (3, 26, 1769),
                      (4, 15, 1770),
                      (3, 31, 1771),
                      (4, 19, 1772),
                      (4, 11, 1773),
                      (4,  3, 1774),
                      (4, 16, 1775),
                      (4,  7, 1776),
                      (3, 30, 1777),
                      (4, 19, 1778),
                      (4,  4, 1779),
                      (3, 26, 1780),
                      (4, 15, 1781),
                      (3, 31, 1782),
                      (4, 20, 1783),
                      (4, 11, 1784),
                      (3, 27, 1785),
                      (4, 16, 1786),
                      (4,  8, 1787),
                      (3, 23, 1788),
                      (4, 12, 1789),
                      (4,  4, 1790),
                      (4, 24, 1791),
                      (4,  8, 1792),
                      (3, 31, 1793),
                      (4, 20, 1794),
                      (4,  5, 1795),
                      (3, 27, 1796),
                      (4, 16, 1797),
                      (4,  8, 1798),
                      (3, 24, 1799),
                      (4, 13, 1800),
                      (4,  5, 1801),
                      (4, 18, 1802),
                      (4, 10, 1803),
                      (4,  1, 1804),
                      (4, 14, 1805),
                      (4,  6, 1806),
                      (3, 29, 1807),
                      (4, 17, 1808),
                      (4,  2, 1809),
                      (4, 22, 1810),
                      (4, 14, 1811),
                      (3, 29, 1812),
                      (4, 18, 1813),
                      (4, 10, 1814),
                      (3, 26, 1815),
                      (4, 14, 1816),
                      (4,  6, 1817),
                      (3, 22, 1818),
                      (4, 11, 1819),
                      (4,  2, 1820),
                      (4, 22, 1821),
                      (4,  7, 1822),
                      (3, 30, 1823),
                      (4, 18, 1824),
                      (4,  3, 1825),
                      (3, 26, 1826),
                      (4, 15, 1827),
                      (4,  6, 1828),
                      (4, 19, 1829),
                      (4, 11, 1830),
                      (4,  3, 1831),
                      (4, 22, 1832),
                      (4,  7, 1833),
                      (3, 30, 1834),
                      (4, 19, 1835),
                      (4,  3, 1836),
                      (3, 26, 1837),
                      (4, 15, 1838),
                      (3, 31, 1839),
                      (4, 19, 1840),
                      (4, 11, 1841),
                      (3, 27, 1842),
                      (4, 16, 1843),
                      (4,  7, 1844),
                      (3, 23, 1845),
                      (4, 12, 1846),
                      (4,  4, 1847),
                      (4, 23, 1848),
                      (4,  8, 1849),
                      (3, 31, 1850),
                      (4, 20, 1851),
                      (4, 11, 1852),
                      (3, 27, 1853),
                      (4, 16, 1854),
                      (4,  8, 1855),
                      (3, 23, 1856),
                      (4, 12, 1857),
                      (4,  4, 1858),
                      (4, 24, 1859),
                      (4,  8, 1860),
                      (3, 31, 1861),
                      (4, 20, 1862),
                      (4,  5, 1863),
                      (3, 27, 1864),
                      (4, 16, 1865),
                      (4,  1, 1866),
                      (4, 21, 1867),
                      (4, 12, 1868),
                      (3, 28, 1869),
                      (4, 17, 1870),
                      (4,  9, 1871),
                      (3, 31, 1872),
                      (4, 13, 1873),
                      (4,  5, 1874),
                      (3, 28, 1875),
                      (4, 16, 1876),
                      (4,  1, 1877),
                      (4, 21, 1878),
                      (4, 13, 1879),
                      (3, 28, 1880),
                      (4, 17, 1881),
                      (4,  9, 1882),
                      (3, 25, 1883),
                      (4, 13, 1884),
                      (4,  5, 1885),
                      (4, 25, 1886),
                      (4, 10, 1887),
                      (4,  1, 1888),
                      (4, 21, 1889),
                      (4,  6, 1890),
                      (3, 29, 1891),
                      (4, 17, 1892),
                      (4,  2, 1893),
                      (3, 25, 1894),
                      (4, 14, 1895),
                      (4,  5, 1896),
                      (4, 18, 1897),
                      (4, 10, 1898),
                      (4,  2, 1899),
                      (4, 15, 1900),
                      (4,  7, 1901),
                      (3, 30, 1902),
                      (4, 12, 1903),
                      (4,  3, 1904),
                      (4, 23, 1905),
                      (4, 15, 1906),
                      (3, 31, 1907),
                      (4, 19, 1908),
                      (4, 11, 1909),
                      (3, 27, 1910),
                      (4, 16, 1911),
                      (4,  7, 1912),
                      (3, 23, 1913),
                      (4, 12, 1914),
                      (4,  4, 1915),
                      (4, 23, 1916),
                      (4,  8, 1917),
                      (3, 31, 1918),
                      (4, 20, 1919),
                      (4,  4, 1920),
                      (3, 27, 1921),
                      (4, 16, 1922),
                      (4,  1, 1923),
                      (4, 20, 1924),
                      (4, 12, 1925),
                      (4,  4, 1926),
                      (4, 17, 1927),
                      (4,  8, 1928),
                      (3, 31, 1929),
                      (4, 20, 1930),
                      (4,  5, 1931),
                      (3, 27, 1932),
                      (4, 16, 1933),
                      (4,  1, 1934),
                      (4, 21, 1935),
                      (4, 12, 1936),
                      (3, 28, 1937),
                      (4, 17, 1938),
                      (4,  9, 1939),
                      (3, 24, 1940),
                      (4, 13, 1941),
                      (4,  5, 1942),
                      (4, 25, 1943),
                      (4,  9, 1944),
                      (4,  1, 1945),
                      (4, 21, 1946),
                      (4,  6, 1947),
                      (3, 28, 1948),
                      (4, 17, 1949),
                      (4,  9, 1950),
                      (3, 25, 1951),
                      (4, 13, 1952),
                      (4,  5, 1953),
                      (4, 18, 1954),
                      (4, 10, 1955),
                      (4,  1, 1956),
                      (4, 21, 1957),
                      (4,  6, 1958),
                      (3, 29, 1959),
                      (4, 17, 1960),
                      (4,  2, 1961),
                      (4, 22, 1962),
                      (4, 14, 1963),
                      (3, 29, 1964),
                      (4, 18, 1965),
                      (4, 10, 1966),
                      (3, 26, 1967),
                      (4, 14, 1968),
                      (4,  6, 1969),
                      (3, 29, 1970),
                      (4, 11, 1971),
                      (4,  2, 1972),
                      (4, 22, 1973),
                      (4, 14, 1974),
                      (3, 30, 1975),
                      (4, 18, 1976),
                      (4, 10, 1977),
                      (3, 26, 1978),
                      (4, 15, 1979),
                      (4,  6, 1980),
                      (4, 19, 1981),
                      (4, 11, 1982),
                      (4,  3, 1983),
                      (4, 22, 1984),
                      (4,  7, 1985),
                      (3, 30, 1986),
                      (4, 19, 1987),
                      (4,  3, 1988),
                      (3, 26, 1989),
                      (4, 15, 1990),
                      (3, 31, 1991),
                      (4, 19, 1992),
                      (4, 11, 1993),
                      (4,  3, 1994),
                      (4, 16, 1995),
                      (4,  7, 1996),
                      (3, 30, 1997),
                      (4, 12, 1998),
                      (4,  4, 1999),
                      (4, 23, 2000),
                      (4, 15, 2001),
                      (3, 31, 2002),
                      (4, 20, 2003),
                      (4, 11, 2004),
                      (3, 27, 2005),
                      (4, 16, 2006),
                      (4,  8, 2007),
                      (3, 23, 2008),
                      (4, 12, 2009),
                      (4,  4, 2010),
                      (4, 24, 2011),
                      (4,  8, 2012),
                      (3, 31, 2013),
                      (4, 20, 2014),
                      (4,  5, 2015),
                      (3, 27, 2016),
                      (4, 16, 2017),
                      (4,  1, 2018),
                      (4, 21, 2019),
                      (4, 12, 2020),
                      (4,  4, 2021),
                      (4, 17, 2022),
                      (4,  9, 2023),
                      (3, 31, 2024),
                      (4, 20, 2025),
                      (4,  5, 2026),
                      (3, 28, 2027),
                      (4, 16, 2028),
                      (4,  1, 2029),
                      (4, 21, 2030),
                      (4, 13, 2031),
                      (3, 28, 2032),
                      (4, 17, 2033),
                      (4,  9, 2034),
                      (3, 25, 2035),
                      (4, 13, 2036),
                      (4,  5, 2037),
                      (4, 25, 2038),
                      (4, 10, 2039),
                      (4,  1, 2040),
                      (4, 21, 2041),
                      (4,  6, 2042),
                      (3, 29, 2043),
                      (4, 17, 2044),
                      (4,  9, 2045),
                      (3, 25, 2046),
                      (4, 14, 2047),
                      (4,  5, 2048),
                      (4, 18, 2049),
                      (4, 10, 2050),
                      (4,  2, 2051),
                      (4, 21, 2052),
                      (4,  6, 2053),
                      (3, 29, 2054),
                      (4, 18, 2055),
                      (4,  2, 2056),
                      (4, 22, 2057),
                      (4, 14, 2058),
                      (3, 30, 2059),
                      (4, 18, 2060),
                      (4, 10, 2061),
                      (3, 26, 2062),
                      (4, 15, 2063),
                      (4,  6, 2064),
                      (3, 29, 2065),
                      (4, 11, 2066),
                      (4,  3, 2067),
                      (4, 22, 2068),
                      (4, 14, 2069),
                      (3, 30, 2070),
                      (4, 19, 2071),
                      (4, 10, 2072),
                      (3, 26, 2073),
                      (4, 15, 2074),
                      (4,  7, 2075),
                      (4, 19, 2076),
                      (4, 11, 2077),
                      (4,  3, 2078),
                      (4, 23, 2079),
                      (4,  7, 2080),
                      (3, 30, 2081),
                      (4, 19, 2082),
                      (4,  4, 2083),
                      (3, 26, 2084),
                      (4, 15, 2085),
                      (3, 31, 2086),
                      (4, 20, 2087),
                      (4, 11, 2088),
                      (4,  3, 2089),
                      (4, 16, 2090),
                      (4,  8, 2091),
                      (3, 30, 2092),
                      (4, 12, 2093),
                      (4,  4, 2094),
                      (4, 24, 2095),
                      (4, 15, 2096),
                      (3, 31, 2097),
                      (4, 20, 2098),
                      (4, 12, 2099)
                };
                foreach (var (month, date, year) in official)
                    yield return new DateTime(year, month, date);
            }
        }
    }
}